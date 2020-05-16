using System;
using System.Windows.Forms;

namespace Proyecto_Arkanoid
{
    public partial class Registration_Window : Form
    {
        public Registration_Window()
        {
            InitializeComponent();
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            
            Ventana_Inicio inicio = new Ventana_Inicio();
            inicio.Show(); 
            Close();
        }
    }
}