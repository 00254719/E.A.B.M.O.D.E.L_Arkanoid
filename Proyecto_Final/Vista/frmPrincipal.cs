using System;
using System.Windows.Forms;
using System.Drawing;

namespace Proyecto_Final.Vista
{
    public partial class frmPrincipal : Form
    {

        private UserControl current;
        private MainMenu mn = new MainMenu();
        private UserRegister rg = new UserRegister();
        private UserLevelOne lv = new UserLevelOne();
        
        public frmPrincipal()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
            current = menu1;

            // cargar el usercontrol de Register
            rg.Dock = DockStyle.Fill;
            rg.Height = Height;
            rg.Width = Width;
            Controls.Add(rg);
            rg.Hide();

            // Cargar el usercontrol de; Menu
            menu1.Dock = DockStyle.Fill;
            menu1.Height = Height;
            menu1.Width = Width;
            Controls.Add(menu1);
        }

        //metodo para pasar el Usercontrol Register.
        private void UserControl1_ButtonClick(object sender, EventArgs e)
        {
            menu1.Hide();
            rg.Show();
        }

        //metodo para volver al Usecontrol menu1.
        private void UserControl2_BtnBackMenu(object sender, EventArgs e)
        {
            rg.Hide();
            menu1.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            // suscripciones de los metodos para los usercontrols
            menu1.btnPlay_Click1 += new EventHandler(UserControl1_ButtonClick);
            rg.btnBack_Click2 += new EventHandler(UserControl2_BtnBackMenu);
            rg.OnClickButtonPgame += ClickStartGame;

            // Mensaje al terminar o perder el juego.
            lv.EndGame = () =>
            {
                lv = null;
                lv = new UserLevelOne();

                MessageBox.Show("Has perdido");

            };
        }

        // para mostrar el usercontrol del juego.
        private void ClickStartGame(object sender, EventArgs e)
        {
            rg.Hide();
            lv.Dock = DockStyle.Fill;
            lv.Height = Height;
            lv.Width = Width;
            Controls.Add(lv);
        }

    }
}
