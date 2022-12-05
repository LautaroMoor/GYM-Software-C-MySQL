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
    public partial class frmRegistro : Form
    {
        static MySqlConnection miConexion = conexion.getConexion();
        public frmRegistro()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Cerrar sistema, ¿confirma ? ", "Gimnasio", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
                Application.Exit();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal p = new frmPrincipal();
            this.Visible = false;
            p.Show();
        }
        private void cargarUsuarios()
        {
            cbxTipos.DataSource = null;
            cbxTipos.Items.Clear();
            miConexion.Open();
            try
            {
                string consulta = "Select * from tipousuario";
                MySqlCommand comando = new MySqlCommand(consulta, miConexion);
                MySqlDataAdapter mysqldt = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                mysqldt.Fill(dt);
                cbxTipos.ValueMember = "idTipo";
                cbxTipos.DisplayMember = "Nombre";
                cbxTipos.DataSource = dt;
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                usuario user = new usuario();
                user.Usuarii = txtUsuario.Text;
                user.Password = txtContra.Text;
                user.PasswordConfirma = txtContraCon.Text;
                user.Nombre = txtNombre.Text;
                user.IdTipo = int.Parse(cbxTipos.SelectedValue.ToString());
                controlUsuarios control = new controlUsuarios();
                MessageBox.Show(control.ctrlRegistroUsuarios(user), "Control deusuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            cargarUsuarios();
        }
    }
}
