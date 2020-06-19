using System;
using System.Windows.Forms;
using System.Drawing;
using Proyecto_Final.Controlador;

namespace Proyecto_Final.Vista
{
    public partial class frmPrincipal : Form
    {

        private UserControl current;
        private MainMenu mn = new MainMenu();
        private UserRegister rg = new UserRegister();
        private UserLevelOne lv;


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

        }

        // para mostrar el usercontrol del juego.
        private void ClickStartGame(object sender, EventArgs e)
        {
            DataGame.InicializateGame();

            lv = new UserLevelOne();
            rg.Hide();
            lv.Dock = DockStyle.Fill;
            lv.Height = Height;
            lv.Width = Width;
            Controls.Add(lv);

            // Mensaje al terminar o perder el juego.
            lv.EndGame = () =>
            {
                MessageBox.Show("Has perdido");

                Controls.Remove(lv);
                menu1.Show();

            };

            // Seteo de Delegate que maneja cuando se gana el juego
            lv.WinningGame = () =>
            {
                MessageBox.Show("Has ganado!");

                Controls.Remove(lv);
                menu1.Show();
            };
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
