using Proyecto_Final.Controlador;
using System;
using System.Media;
using System.Windows.Forms;

namespace Proyecto_Final.Vista
{
    public partial class UserRegister : UserControl
    {
        public delegate void EventUserRegister(object sender, EventArgs e);
        public EventUserRegister OnClickButtonPgame;
        public event EventHandler btnBack_Click2;

        public delegate void GetNickname(string text);
        public GetNickname Ur;

        public UserRegister()
        {
            InitializeComponent();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

            OptimizeTableLayoutPanel();
        }
        
        // Evento del boton para volver al menu
        private void btnBack_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer("../../Resources/SonidoBoton.wav");
            simpleSound.Play();
            if (this.btnBack_Click2 != null)
                this.btnBack_Click2(sender: this, e);
        }

        // Evento del boton para iniciar el juego
        private void btnPgame_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer("../../Resources/SonidoBoton.wav");
            simpleSound.Play();
            if (OnClickButtonPgame != null)
            {
               OnClickButtonPgame(this, e);
            }
            try
            {
                switch (richTextBox1.Text)
                {
                    case string aux when aux.Length > 15:
                        throw new ExceededMaxCharactersException("No se puede introducir un nick de mas de 15 car");
                    case string aux when aux.Trim().Length == 0:
                        throw new EmptyNicknameException("No puede dejar campos vacios");
                    default:
                        Ur?.Invoke(richTextBox1.Text);
                        richTextBox1.Text = "";
                        break;
                }
            }
            catch (EmptyNicknameException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ExceededMaxCharactersException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //metodo para cargar el contenido de las tablelayoutpanel sin tanto delay y de forma mas optima
        private void OptimizeTableLayoutPanel()
        {
            Type tp = RegisterTable.GetType().BaseType;
            System.Reflection.PropertyInfo pi =
                tp.GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.NonPublic);
            pi.SetValue(RegisterTable, true, null);
        }

        //Optimizacion a la hora de dibujar los UserControl
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
