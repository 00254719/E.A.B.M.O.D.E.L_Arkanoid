using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final.Vista
{
    public partial class frmLevel : Form
    {
        private int increment;

        public frmLevel()
        {
            InitializeComponent();
            increment = 10;
            WindowState = FormWindowState.Maximized;
            Height = Screen.PrimaryScreen.Bounds.Height;
            Width = Screen.PrimaryScreen.Bounds.Width;

        }

        private void frmLevel_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0); //Para que se acople a la pantalla
            this.Size = new Size(this.Width, Screen.PrimaryScreen.WorkingArea.Size.Height);
        }
        
        private void frmLeve_MouseMove(object sender, MouseEventArgs e)
        {
            picBounceBar.Left = e.X;
        }
    }
}
