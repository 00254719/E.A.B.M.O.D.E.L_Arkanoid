using Proyecto_Final.Modelo;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Proyecto_Final.Vista
{
    public partial class Register : UserControl
    {
        public event EventHandler btnPlay_Click2;
        public Register()
        {
            InitializeComponent();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.btnPlay_Click2 != null)
                this.btnPlay_Click2(sender: this, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmLevel lv = new frmLevel();
            ParentForm.Hide();
            lv.Show();
        }
    }
}
