using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimnasio
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        private void btnSacar_Click(object sender, EventArgs e)
        {
            frmTurnos p = new frmTurnos();
            this.Visible = false;
            p.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            inicio p = new inicio();
            this.Visible = false;
            p.Show();
        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
            frmDatos p = new frmDatos();
            this.Visible = false;
            p.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Cerrar sistema, ¿confirma ? ", "Gimnasio", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistro p = new frmRegistro();
            this.Visible = false;
            p.Show();
        }

        private void btnPrecios_Click(object sender, EventArgs e)
        {
            frmPrecios p = new frmPrecios();
            this.Visible = false;
            p.Show();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            frmPagos p = new frmPagos();
            this.Visible = false;
            p.Show();
        }
    }
}
