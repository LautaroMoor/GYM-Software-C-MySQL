using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gimnasio
{
    public partial class inicio : Form
    {
        public inicio()
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

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                String usuario = txtUsuario.Text;
                String pass = txtPassword.Text;
                controlSesion control = new controlSesion();
                String respuestaControlador = control.ctrlLogin(usuario, pass);
                if (respuestaControlador == "¡Bienvenido!")
                {
                    //MessageBox.Show(control.ctrlLogin(usuario, pass), "Control de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmPrincipal p = new frmPrincipal();
                    this.Visible = false; //Oculta el formulario de inicio de sesión.
                    p.Show();
                }
                else
                {
                    MessageBox.Show(respuestaControlador, "Control de usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (txtUsuario.Text == "")
                        txtUsuario.Focus();
                    else
                        txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
