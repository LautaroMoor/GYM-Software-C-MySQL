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
    public partial class frmPrecios : Form
    {
        static MySqlConnection miConexion = conexion.getConexion();
        static string sql = "";
        public frmPrecios()
        {
            InitializeComponent();
        }

        private void frmPrecios_Load(object sender, EventArgs e)
        {
            cargarVeces();
        }
        private void cargarVeces()
        {
            //CANTIDAD
            cbxVeces.DataSource = null;
            cbxVeces.Items.Clear();
            miConexion.Open();
            try
            {
                string consulta = "Select * from veces";
                MySqlCommand comando = new MySqlCommand(consulta, miConexion);
                MySqlDataAdapter mysqldt = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                mysqldt.Fill(dt);
                cbxVeces.ValueMember = "cantidad";
                cbxVeces.DisplayMember = "cantidad";
                cbxVeces.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                miConexion.Close();
            }
        }    
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Cerrar sistema, ¿confirma ? ", "Gimnasio", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
                try
                {
                    if (string.IsNullOrEmpty(txtPrecio.Text) || int.Parse(txtPrecio.Text) <= 0)
                    {
                        if(string.IsNullOrEmpty(txtPrecio.Text))
                            MessageBox.Show("Ingrese un precio", "Control de precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Ingrese un precio mayor que 0", "Control de precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrecio.Focus();
                    }
                    else
                    {
                        precio Precio = new precio();
                        Precio.Cantidad = int.Parse(cbxVeces.Text);
                        Precio.Valor = int.Parse(txtPrecio.Text);
                        
                        controlPrecio control = new controlPrecio();
                        MessageBox.Show(control.ctrlModificarPrecios(Precio), "Control de precios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        } 

        private void btnVer_Click(object sender, EventArgs e)
        {
            miConexion.Open();
            sql = "select veces.precio FROM veces WHERE veces.cantidad = @cantidad";

            MySqlCommand comando = new MySqlCommand(sql, miConexion);
            comando.Parameters.AddWithValue("@cantidad", cbxVeces.Text);
            MySqlDataReader busqueda = comando.ExecuteReader();
            while (busqueda.Read())
                txtPrecio.Text = busqueda["precio"].ToString();
            miConexion.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal p = new frmPrincipal();
            this.Visible = false;
            p.Show();
        }
    }
}
