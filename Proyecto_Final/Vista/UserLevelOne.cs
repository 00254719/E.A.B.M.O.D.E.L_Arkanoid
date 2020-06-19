using System;
using System.Drawing;
using System.Windows.Forms;
using Proyecto_Final.Modelo;
using Proyecto_Final.Controlador;

namespace Proyecto_Final.Vista
{
    public partial class UserLevelOne : UserControl
    {
        private Panel Scores;
        private Label RemanentLife, Points;
        private CustomPictureBox [,] cpb;
        private PictureBox ball;

        private int remainingBlocks = 0;

        private PictureBox Heart;

        private delegate void ActionBall();
        private readonly ActionBall MoveBall;
        public Action EndGame;
        public Action FinishGame, WinningGame;

        public UserLevelOne()
        {
            InitializeComponent();

            MoveBall = RebounceBall;
            MoveBall += Start_Move_Ball;
        }

        //Optimizacion el UserControl
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        // Metodos que coinciden con el delegate de Event
        private void UserLevelOne_Load(object sender, EventArgs e)
        {
            BackColor = Color.Transparent;

            ScoresPanel();

            // Asignando atributos a la barra del jugador
            picPlayerBar.BackgroundImage = Image.FromFile("../../Resources/Bar2.png");
            picPlayerBar.BackgroundImageLayout = ImageLayout.Stretch;

            picPlayerBar.Top = Height - picPlayerBar.Height - 80;
            picPlayerBar.Left = (Width / 2) - (picPlayerBar.Width / 2);

            // Asignando atributos a la pelota.
            ball = new PictureBox();
            ball.Width = ball.Height = 20;
            ball.BackgroundImage = Image.FromFile("../../Resources/Ball.png");
            ball.BackgroundImageLayout = ImageLayout.Stretch;

            ball.Top = picPlayerBar.Top - ball.Height;
            ball.Left = picPlayerBar.Left + (picPlayerBar.Width / 2) - (ball.Width / 2);

            Controls.Add(ball);

            LoadBlocks();
        }

        // Metodo para Cargar los bloques.
        private void LoadBlocks()
        {
            // Variables auxiliares para el calculo de tamano de cada cpb
            int xAxis = 10, yAxis = 5;
            remainingBlocks = xAxis * yAxis;

            int pbWidth = (Width - (xAxis - 5)) / xAxis;
            int pbHeight = (int)(Height * 0.3) / yAxis;

            cpb = new CustomPictureBox[yAxis, xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    cpb[i, j] = new CustomPictureBox();

                    if (i == 0)
                    {
                        cpb[i, j].Hits = 3;
                        cpb[i, j].BackgroundImage = Image.FromFile("../../Resources/Brick_Lvl3.jpg");
                        cpb[i, j].Tag = "blockLevel3";
                    }
                    else if (i == 1 || i == 2)
                    {
                        cpb[i, j].Hits = 2;
                        cpb[i, j].BackgroundImage = Image.FromFile("../../Resources/Brick_Lvl2.jpg");
                        cpb[i, j].Tag = "blockLevel2";
                    }
                    else
                    {
                        cpb[i, j].Hits = 1;
                        cpb[i, j].BackgroundImage = Image.FromFile("../../Resources/Brick_Lvl1.jpg");
                        cpb[i, j].Tag = "blockLevel1";
                    }
                    // Tamano del cpb
                    cpb[i, j].Height = pbHeight;
                    cpb[i, j].Width = pbWidth;

                    // Posicion de left, y posicion de top
                    cpb[i, j].Left = j * pbWidth;
                    cpb[i, j].Top = i * pbHeight;
                    cpb[i, j].Top = i * pbHeight + Scores.Height + 1;

                    cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;

                    Controls.Add(cpb[i, j]);
                }
            }
        }
       
        // Seguimiento de la barra al movimiento del mouse
        private void UserLevelOne_MouseMove(object sender, MouseEventArgs e)
        {
            if (!DataGame.GameStart)
            {
                if (e.X < (Width - picPlayerBar.Width))
                {
                    picPlayerBar.Left = e.X;
                    ball.Left = picPlayerBar.Left + (picPlayerBar.Width / 2) - (ball.Width / 2);
                }
            }
            else
            {
                if (e.X < (Width - picPlayerBar.Width))
                    picPlayerBar.Left = e.X;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!DataGame.GameStart)
                return;

            MoveBall?.Invoke();
        }

        // para que la pelota inicie a moverse
        private void UserLevelOne_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                DataGame.GameStart = true;
                timer1.Start();
            }
        }

        // rebote de la pelota
        private void RebounceBall()
        {
            if (ball.Top < Scores.Height)
                DataGame.dirY = -DataGame.dirY;

            if (ball.Bottom > Height)
            {
                DataGame.lifes--;
                DataGame.GameStart = false;
                timer1.Stop();

                ReloadElements();
                UpdateElements();

                if (DataGame.lifes == 0)
                {
                    timer1.Stop();
                    EndGame?.Invoke();
                }
            }

            if (ball.Left < 0 || ball.Right > Width)
            {
                DataGame.dirX = -DataGame.dirX;
                return;
            }

            if (ball.Bounds.IntersectsWith(picPlayerBar.Bounds))
            {
                DataGame.dirY = -DataGame.dirY;
            }

            // Coliciones con los bloques
            for (int i = 4; i >= 0; i--)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (cpb[i, j] != null && ball.Bounds.IntersectsWith(cpb[i, j].Bounds))
                    {
                        if (cpb[i, j].Hits == 3)
                        {
                            DataGame.score += (3 * DataGame.lifes);
                            cpb[i, j].Hits--;

                            // cambio de imagen de fondo segun los golpes
                            cpb[i, j].BackgroundImage = Image.FromFile("../../Resources/Brick_Lvl3_Semibroken.jpg");
                        }
                        else if (cpb[i, j].Hits == 2)
                        {
                            DataGame.score += (3 * DataGame.lifes);
                            cpb[i, j].Hits--;

                            // cambio de imagen de fondo segun los golpes
                            if(cpb[i, j].Tag.Equals("blockLevel3"))
                                cpb[i, j].BackgroundImage = Image.FromFile("../../Resources/Brick_Lvl3_Broken.jpg");
                            else if (cpb[i, j].Tag.Equals("blockLevel2"))
                                cpb[i, j].BackgroundImage = Image.FromFile("../../Resources/Brick_Lvl2_Broken.jpg");
                        }
                        else if (cpb[i, j].Hits == 1)
                        {
                            DataGame.score += (3 * DataGame.lifes);
                            cpb[i, j].Hits--;
                        }
                        if (cpb[i, j].Hits == 0)
                        {
                            Controls.Remove(cpb[i, j]);
                            cpb[i, j] = null;

                            remainingBlocks--;
                        }

                        DataGame.dirY = -DataGame.dirY;
                        Points.Text = DataGame.score.ToString();

                        if (remainingBlocks == 0)
                        {
                            timer1.Stop();
                            WinningGame?.Invoke();
                        }
                            

                        return;
                    }
                }
            }
        }

        // Movimiento de la pelota
        private void Start_Move_Ball()
        {
            ball.Left += DataGame.dirX;
            ball.Top += DataGame.dirY;
        }

        // panel de puntajes y vidas
        private void ScoresPanel()
        {
            // Instanciar panel
            Scores = new Panel();

            // Setear elementos del panel
            Scores.Width = Width;
            Scores.Height = (int)(Height * 0.07);

            Scores.Top = Scores.Left = 0;

            Scores.BackColor = Color.Black;

            #region Label + PictureBox
            // Instanciar pb
            Heart = new PictureBox();

            Heart.Height = Heart.Width = Scores.Height;

            Heart.Top = 0;
            Heart.Left = 20;

            Heart.BackgroundImage = Image.FromFile("../../Resources/Heart.png");
            Heart.BackgroundImageLayout = ImageLayout.Stretch;
            #endregion
                        
            // Instanciar labels
            RemanentLife = new Label();
            Points = new Label();

            // Setear elementos de los labels
            RemanentLife.ForeColor = Points.ForeColor = Color.White;

            RemanentLife.Text = "x " + DataGame.lifes.ToString();
            Points.Text = DataGame.score.ToString();

            RemanentLife.Font = Points.Font = new Font("Barcade No Bar Bold", 24F);
            RemanentLife.TextAlign = Points.TextAlign = ContentAlignment.MiddleCenter;

            RemanentLife.Left = Heart.Right + 5;
            Points.Left = Width - 100;

            RemanentLife.Height = Points.Height = Scores.Height;

            Scores.Controls.Add(Heart);
            Scores.Controls.Add(RemanentLife);
            Scores.Controls.Add(Points);
                       
            Controls.Add(Scores);
        }

        private void ReloadElements()
        {
            picPlayerBar.Left = (Width / 2) - (picPlayerBar.Width / 2);
            ball.Top = picPlayerBar.Top - ball.Height;
            ball.Left = picPlayerBar.Left + (picPlayerBar.Width / 2) - (ball.Width / 2);
        }

        private void UpdateElements()
        {
            RemanentLife.Text = "x " + DataGame.lifes.ToString();

        }

    }
}
