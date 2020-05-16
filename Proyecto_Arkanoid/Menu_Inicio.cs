using System;
using System.Windows.Forms;

namespace Proyecto_Arkanoid
{
    public partial class Menu_Inicio : UserControl
    {
        public Menu_Inicio()
        {
            InitializeComponent();
        }

        
        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Jugar_Click(object sender, EventArgs e)
        {
           ParentForm.Hide();
           Registration_Window Ventana = new Registration_Window();
           Ventana.Show();
        }

        private void btn_Puntajes_Click(object sender, EventArgs e)
        {
            Ventana_Puntajes ventanaPuntos = new Ventana_Puntajes();
            ventanaPuntos.Show();
        }
    }
}