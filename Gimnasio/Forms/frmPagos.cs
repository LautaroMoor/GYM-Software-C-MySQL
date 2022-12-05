using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gimnasio
{
    public partial class frmPagos : Form
    {
        static MySqlConnection miConexion = conexion.getConexion();
        static string sql = "";
        public frmPagos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Cerrar sistema, ¿confirma ? ", "Gimnasio", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(txtDNI.Text) || (txtDNI.Text.Length < 8))) 
                {
                    if (txtDNI.Text.Length < 8)
                        MessageBox.Show("El DNI tiene que tener 8 digitos!", "Control de pagos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Llene todos los campos de texto para registrar!", "Control de pagos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDNI.Focus();
                    limpiar();
                }
                else { 
                    miConexion.Open();
                    sql = "SELECT CONCAT(socio.nombre,' ',socio.apellido) AS nombre_completo, socio.vieneVeces, veces.precio FROM socio INNER JOIN veces ON socio.vieneVeces = veces.cantidad WHERE dni = @dni";
                    MySqlCommand comando = new MySqlCommand(sql, miConexion);
                    comando.Parameters.AddWithValue("@dni", txtDNI.Text);
                    MySqlDataReader busqueda = comando.ExecuteReader();
                    while (busqueda.Read())
                    {
                        txtNombre.Text = busqueda["nombre_completo"].ToString();
                        txtCantidad.Text = busqueda["vieneVeces"].ToString();
                        txtPagar.Text = busqueda["precio"].ToString();
                    }
                    miConexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void limpiar()
        {
            txtDNI.Text = ""; txtNombre.Text = ""; txtCantidad.Text = ""; txtPagar.Text = "";
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal p = new frmPrincipal();
            this.Visible = false;
            p.Show();
        }
        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(dateTimePicker1.Text) ||
                ((string.IsNullOrEmpty(txtDNI.Text) || (txtDNI.Text.Length < 8))) ||
                (string.IsNullOrEmpty(txtNombre.Text))||
                (string.IsNullOrEmpty(txtCantidad.Text)))
                {
                    if (txtDNI.Text.Length < 8)
                        MessageBox.Show("El DNI tiene que tener 8 digitos!", "Control de pagos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Llene todos los campos de texto para registrar!", "Control de pagos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDNI.Focus();
                    limpiar();
                }
                else
                {
                    pago Pago = new pago();
                    Pago.FechaPago= DateTime.Parse(dateTimePicker1.Text);
                    Pago.DniSocio = int.Parse(txtDNI.Text);
                    Pago.Precio = int.Parse(txtPagar.Text);

                    controlPago control = new controlPago();
                    MessageBox.Show(control.ctrlRegistroPagos(Pago), "Control de pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Este DNI no esta en la base de datos", "Control de pagos");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
