using Proyecto_Final.Controlador;
using Proyecto_Final.Modelo;
using System;
using System.Windows.Forms;

namespace Proyecto_Final.Vista
{
    public partial class frmPrincipal : Form
    {
        private UserRegister rg = new UserRegister();
        private UserLevelOne lv;
        private Player currentPlayer;


        public frmPrincipal()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;

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
            rg = new UserRegister();
            rg.Dock = DockStyle.Fill;
            rg.Height = Height;
            rg.Width = Width;

            rg.btnBack_Click2 += new EventHandler(UserControl2_BtnBackMenu);
            rg.OnClickButtonPgame += ClickStartGame;

            Controls.Add(rg);
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

            // seteo de propiedades para el UserLevelOne
            lv = new UserLevelOne();

            lv.Dock = DockStyle.Fill;
            lv.Height = Height;
            lv.Width = Width;

            // Mensaje al perder el juego.
            lv.EndGame = () =>
            {
                MessageBox.Show("Has perdido");

                lv.Dispose();
                Controls.Remove(lv);

                menu1.Show();
            };

            // Seteo de Delegate que maneja cuando se gana el juego
            lv.WinningGame = () =>
            {
                int idPlayer = 0;
                try
                {
                    //obtengo el id y luego realizo el insert del nuevo score
                    idPlayer = Player_DAO.QueryIdplayer(currentPlayer.Nickname);
                    Player_DAO.CreateNewScore(idPlayer, DataGame.score);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show("Has ganado!");

                lv.Dispose();
                Controls.Remove(lv);
                menu1.Show();
            };

            // seteo del delegate para registrar un nuevo jugador o acceder como uno existente
            rg.Ur = (string nick) =>
            {
                if (Player_DAO.CreatePlayer(nick))
                {
                    MessageBox.Show($"Bienvenido nuevamenete {nick}");
                }
                else
                {
                    MessageBox.Show($"Gracias por registrarte {nick}");
                }

                rg.Hide();
                Controls.Add(lv);

                currentPlayer = new Player(nick, 0);

                rg.Dispose();
            };
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
