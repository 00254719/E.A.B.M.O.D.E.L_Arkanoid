using System;
using System.Windows.Forms;
using System.Drawing;

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
                frmPrincipal Inicio = new frmPrincipal();
                tmrCargado.Enabled = false;
                Inicio.Show();
                this.Hide();
            }
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0); //Para que se acople a la pantalla
            this.Size = new Size(this.Width, Screen.PrimaryScreen.WorkingArea.Size.Height);
            this.tmrCargado.Start();
        }
    }
}
