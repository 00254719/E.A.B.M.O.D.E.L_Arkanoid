using System;
using System.Windows.Forms;

namespace Proyecto_Final.Vista
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void tmrCargado_Tick(object sender, EventArgs e)
        {
            this.pgbCarga.Increment(1);
            if (pgbCarga.Value < pgbCarga.Maximum)
            {
                pgbCarga.Value++;
            }
            else
            {
                tmrCargado.Enabled = false;
                frmPrincipal Inicio = new frmPrincipal();
                Inicio.Show();
                this.Hide();
            }
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            this.tmrCargado.Start();

        }
    }
}
