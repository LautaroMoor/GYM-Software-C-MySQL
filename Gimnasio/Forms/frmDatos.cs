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
    public partial class frmDatos : Form
    {
        static MySqlConnection miConexion = conexion.getConexion();
        public frmDatos()
        {
            InitializeComponent();
            llenar_tabla();
            cargarCP();
            dataGridView1.RowHeadersVisible = false;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            //FUNCIONA LA PARTE DEL CONTROL, REVISAR MAÑANA
            try
            {
                if ((string.IsNullOrEmpty(txtDNI.Text) || (txtDNI.Text.Length < 8)) ||
                (string.IsNullOrEmpty(txtNombre.Text)) ||
                (string.IsNullOrEmpty(txtApellido.Text)) ||
                (string.IsNullOrEmpty(txtDomicilio.Text)) ||
                (string.IsNullOrEmpty(cbxCp.Text)) ||
                (string.IsNullOrEmpty(dateTimePicker1.Text)) ||
                (string.IsNullOrEmpty(txtTelefono.Text)) ||
                (string.IsNullOrEmpty(txtEmail.Text)) ||
                (string.IsNullOrEmpty(cbxVeces.Text)))
                {
                    if (txtDNI.Text.Length < 8) 
                        MessageBox.Show("El DNI tiene que tener 8 digitos!", "Control de socios", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    else
                        MessageBox.Show("Llene todos los campos de texto para registrar!", "Control de socios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDNI.Focus();
                }
                else {
                    string posibleActivo, posibleLesionado;
                    if (rbSiActivo.Checked)
                        posibleActivo = "Si";
                    else
                        posibleActivo = "No";
                    if (rbSiLesionado.Checked)
                        posibleLesionado = "Si";
                    else
                        posibleLesionado = "No";
                    socio socioo = new socio();
                    socioo.DNI1 = int.Parse(txtDNI.Text);
                    socioo.Nombre = txtNombre.Text;
                    socioo.Apellido = txtApellido.Text;
                    socioo.Domicilio = txtDomicilio.Text;
                    socioo.Cp = int.Parse(cbxCp.Text);
                    socioo.Fecha = Convert.ToDateTime(dateTimePicker1.Text);
                    socioo.Telefono = Int64.Parse(txtTelefono.Text);
                    socioo.Email = txtEmail.Text;
                    socioo.Activo = posibleActivo;
                    socioo.VieneVeces = int.Parse(cbxVeces.Text);
                    socioo.Lesionado = posibleLesionado;
                    socioo.Lesiones = txtLesiones.Text;

                    controlSocio control = new controlSocio();
                    MessageBox.Show(control.ctrlRegistroSocios(socioo), "Control de socios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    llenar_tabla();
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void llenar_tabla()
        {
            miConexion.Open();
            string consulta = "SELECT socio.dni,socio.nombre,socio.apellido,socio.domicilio,codigopostal.Localidad,socio.CP,socio.fecha_nac,socio.telefono,socio.email, socio.activo, socio.vieneVeces, socio.lesionado, socio.lesiones FROM socio INNER JOIN codigopostal ON socio.CP = codigopostal.cp";
            MySqlCommand comando = new MySqlCommand(consulta, miConexion);
            MySqlDataAdapter mysqldt = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();
            mysqldt.Fill(dt);
            dataGridView1.DataSource = dt;
            miConexion.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal p = new frmPrincipal();
            this.Visible = false;
            p.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDNI.Text) || (txtDNI.Text.Length < 8))
                {
                    if (txtDNI.Text.Length < 8)
                        MessageBox.Show("El DNI tiene que tener 8 digitos!", "Control de socios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else 
                        MessageBox.Show("No se encontro a nadie con ese DNI", "Control de socios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDNI.Focus();
                }
                else
                {
                    socio socioo = new socio();
                    socioo.DNI1 = int.Parse(txtDNI.Text);

                    controlSocio control = new controlSocio();
                    MessageBox.Show(control.ctrlEliminarSocios(socioo), "Control de socios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                }
                llenar_tabla();
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtDNI.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDomicilio.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                cbxCp.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                cbxVeces.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                txtLesiones.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
               if ((string.IsNullOrEmpty(txtDNI.Text) || (txtDNI.Text.Length < 8)) ||
                (string.IsNullOrEmpty(txtNombre.Text)) ||
                (string.IsNullOrEmpty(txtApellido.Text)) ||
                (string.IsNullOrEmpty(txtDomicilio.Text)) ||
                (string.IsNullOrEmpty(cbxCp.Text)) ||
                (string.IsNullOrEmpty(dateTimePicker1.Text)) ||
                (string.IsNullOrEmpty(txtTelefono.Text)) ||
                (string.IsNullOrEmpty(txtEmail.Text)) ||
                (string.IsNullOrEmpty(cbxVeces.Text)) ||
                (string.IsNullOrEmpty(txtLesiones.Text)))
                {
                    if (txtDNI.Text.Length < 8)
                        MessageBox.Show("El DNI tiene que tener 8 digitos!", "Control de socios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("No se encontro a nadie con ese DNI", "Control de socios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDNI.Focus();
                }
                else
                {
                    string posibleActivo, posibleLesionado;
                    if (rbSiActivo.Checked)
                        posibleActivo = "Si";
                    else
                        posibleActivo = "No";
                    if (rbSiLesionado.Checked)
                        posibleLesionado = "Si";
                    else
                        posibleLesionado = "No";
                    socio socioo = new socio();
                    socioo.DNI1 = int.Parse(txtDNI.Text);
                    socioo.Nombre = txtNombre.Text;
                    socioo.Apellido = txtApellido.Text;
                    socioo.Domicilio = txtDomicilio.Text;
                    socioo.Cp = int.Parse(cbxCp.Text);
                    socioo.Fecha = Convert.ToDateTime(dateTimePicker1.Text);
                    socioo.Telefono = Int64.Parse(txtTelefono.Text);
                    socioo.Email = txtEmail.Text;
                    socioo.Activo = posibleActivo;
                    socioo.VieneVeces = int.Parse(cbxVeces.Text);
                    socioo.Lesionado = posibleLesionado;
                    socioo.Lesiones = txtLesiones.Text;

                    controlSocio control = new controlSocio();
                    MessageBox.Show(control.ctrlModificarSocios(socioo), "Control de socios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    llenar_tabla();
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void limpiar()
        {
            txtDNI.Text = ""; txtNombre.Text = ""; txtApellido.Text = ""; txtDomicilio.Text = "";
            dateTimePicker1.Text = ""; txtTelefono.Text = ""; txtEmail.Text = "";
            rbSiActivo.Checked = true; rbNoLesionado.Checked = true;  txtLesiones.Text = "";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Cerrar sistema, ¿confirma ? ", "Gimnasio", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                Application.Exit();
            }
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

        private void frmDatos_Load(object sender, EventArgs e)
        {
            cargarVeces();
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void cargarCP()
        {
            cbxCp.DataSource = null;
            cbxCp.Items.Clear();
            miConexion.Open();
            try
            {
                string consulta = "Select * from codigopostal";
                MySqlCommand comando = new MySqlCommand(consulta, miConexion);
                MySqlDataAdapter mysqldt = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                mysqldt.Fill(dt);
                cbxCp.ValueMember = "cp";
                cbxCp.DisplayMember = "cp";
                cbxCp.DataSource = dt;
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
    }
}