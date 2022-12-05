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
    public partial class frmTurnos : Form
    {
        static MySqlConnection miConexion = conexion.getConexion();
        public frmTurnos()
        {
            InitializeComponent();
        }

        private void frmTurnos_Load(object sender, EventArgs e)
        {
            cargarProfesores();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal p = new frmPrincipal();
            this.Visible = false; 
            p.Show();
        }
        private void btnReservar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(dateTimePicker1.Text)||
                (string.IsNullOrEmpty(txtDNI.Text)) ||
                (string.IsNullOrEmpty(txtNombre.Text)) ||
                (string.IsNullOrEmpty(txtProfesor.Text)) ||
                (string.IsNullOrEmpty(cbxProfesores.Text)))
                {
                    MessageBox.Show("Llene todos los campos", "Control de reservas de turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePicker1.Focus();
                }
                else
                {
                    turno Turno = new turno();
                    Turno.FechaTurno = DateTime.Parse(dateTimePicker1.Text);
                    Turno.DniSocio = int.Parse(txtDNI.Text);
                    Turno.DniProfesor = int.Parse(cbxProfesores.Text);

                    controlTurno control = new controlTurno();
                    MessageBox.Show(control.ctrlRegistroTurnos(Turno), "Control de turnos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("El DNI del Socio no esta en la base de datos", "Control de turnos");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
        private void cargarProfesores()
        {
            cbxProfesores.DataSource = null;
            cbxProfesores.Items.Clear();
            miConexion.Open();
            try
            {
                string consulta = "Select * from profesores";
                MySqlCommand comando = new MySqlCommand(consulta, miConexion);
                MySqlDataAdapter mysqldt = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                mysqldt.Fill(dt);
                cbxProfesores.ValueMember = "dni";
                cbxProfesores.DisplayMember = "dni";
                cbxProfesores.DataSource = dt;
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
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void btnVerDniSocio_Click(object sender, EventArgs e)
        {
            string sql = "";
            try
            {
                if ((string.IsNullOrEmpty(txtDNI.Text) || (txtDNI.Text.Length < 8)))
                {
                    if (txtDNI.Text.Length < 8)
                        MessageBox.Show("El DNI tiene que tener 8 digitos!", "Control de pagos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Llene todos los campos de texto para registrar!", "Control de pagos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDNI.Focus();
                }
                else
                {
                    miConexion.Open();
                    sql = "SELECT CONCAT(socio.nombre,' ',socio.apellido) AS nombre_completo FROM socio WHERE dni = @dni";
                    MySqlCommand comando = new MySqlCommand(sql, miConexion);
                    comando.Parameters.AddWithValue("@dni", txtDNI.Text);
                    MySqlDataReader busqueda = comando.ExecuteReader();
                    while (busqueda.Read())
                    { 
                        txtNombre.Text = busqueda["nombre_completo"].ToString();
                    }
                    miConexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnVerProfesor_Click(object sender, EventArgs e)
        {
            string sql = "";
            try
            {
                    miConexion.Open();
                    sql = "SELECT CONCAT(profesores.nombre,' ',profesores.apellido) AS nombre_completo FROM profesores WHERE dni = @dni";
                    MySqlCommand comando = new MySqlCommand(sql, miConexion);
                    comando.Parameters.AddWithValue("@dni", cbxProfesores.Text);
                    MySqlDataReader busqueda = comando.ExecuteReader();
                    while (busqueda.Read())
                    {
                        txtProfesor.Text = busqueda["nombre_completo"].ToString();
                    }
                    miConexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
