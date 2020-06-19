using System;
using System.Windows.Forms;
using System.Drawing;

namespace Proyecto_Final.Vista
{
    public partial class frmInicio : Form
    {
        private UserLevelOne Ulevel;

        public frmInicio()
        {
            InitializeComponent();
            OptimizeTableLayoutPanel();

            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
            Ulevel = new UserLevelOne();
            Ulevel.Dock = DockStyle.Fill;
            Ulevel.Width = Width;
            Ulevel.Height = Height;

            Controls.Add(Ulevel);

            Ulevel.Show();

            this.tmrCargado.Start();
        }

        // Metodo de la Barra de carga
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

        //metodo para cargar el contenido de las tablelayoutpanel sin tanto delay y de forma mas optima.
        private void OptimizeTableLayoutPanel()
        {
            Type tp = tableLayoutPanel1.GetType().BaseType;
            System.Reflection.PropertyInfo pi =
                tp.GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.NonPublic);
            pi.SetValue(tableLayoutPanel1, true, null);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
    }

}
