using System;
using System.Windows.Forms;
using System.Drawing;

namespace Proyecto_Final.Vista
{
    public partial class frmPrincipal : Form
    {

        private UserControl current;
        private MainMenu mn = new MainMenu();
        private Register rg = new Register();
        public frmPrincipal()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            current = menu1;
            menu1.btnPlay_Click1 += new EventHandler(UserControl1_ButtonClick);
            rg.btnPlay_Click2 += new EventHandler(UserControl2_ButtonClick2);
        }

        private void UserControl1_ButtonClick(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            tableLayoutPanel1.Controls.Add(rg, 0, 0);
            current = rg;
            tableLayoutPanel1.SetColumnSpan(current, 2);
            tableLayoutPanel1.SetRowSpan(current, 2);
            current.Dock = System.Windows.Forms.DockStyle.Fill;

        }

        private void UserControl2_ButtonClick2(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            tableLayoutPanel1.Controls.Add(menu1, 0, 0);
            current = menu1;
            tableLayoutPanel1.SetColumnSpan(current, 2);
            tableLayoutPanel1.SetRowSpan(current, 2);
            current.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0); //Para que se acople a la pantalla
            this.Size = new Size(this.Width, Screen.PrimaryScreen.WorkingArea.Size.Height);
        }

    }
}
