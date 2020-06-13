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
            Type tp = tableLayoutPanel1.GetType().BaseType;
            System.Reflection.PropertyInfo pi =
                tp.GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.NonPublic);
            pi.SetValue(tableLayoutPanel1, true, null);

            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
            Ulevel = new UserLevelOne();
            Ulevel.Dock = DockStyle.Fill;
            Ulevel.Width = Width;
            Ulevel.Height = Height;

            Controls.Add(Ulevel);

            Ulevel.Show();
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
