using System;
using System.Media;
using System.Windows.Forms;

namespace Proyecto_Final.Vista
{
    public partial class UserMenu : UserControl
    {
        public event EventHandler btnPlay_Click1;
        public UserMenu()
        {
            InitializeComponent();
            OptimizeTableLayoutPanel();
        }

        // Evento del boton Play, este lleva a Registrar al jugador antes de jugar
        private void btnPlay_Click(object sender, EventArgs e)
        {

            SoundPlayer simpleSound = new SoundPlayer("../../Resources/SonidoBoton.wav");
            simpleSound.Play();
            if (this.btnPlay_Click1 != null)
                this.btnPlay_Click1(sender: this, e);

        }

        // Evento del boton para mostrar el Top10
        private void btnTop10_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer("../../Resources/SonidoBoton.wav");
            simpleSound.Play();
            frmTop10 Top = new frmTop10();
            Top.Show();
        }

        // Evento del boton Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer("../../Resources/SonidoBoton.wav");
            simpleSound.Play();
            Application.Exit();
        }

        //metodo para cargar el contenido de las tablelayoutpanel sin tanto delay y de forma mas optima
        private void OptimizeTableLayoutPanel()
        {
            Type tp = tableLayoutPanel1.GetType().BaseType;
            System.Reflection.PropertyInfo pi =
                tp.GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.NonPublic);
            pi.SetValue(tableLayoutPanel1, true, null);
        }
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
