using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Final.Modelo;
using Proyecto_Final.Controlador;

namespace Proyecto_Final.Vista
{
    public partial class UserLevelOne : UserControl
    {
        private CustomPictureBox [,] cpb;
        private PictureBox ball;

        private delegate void ActionBall();
        private readonly ActionBall MoveBall;
        public Action EndGame;
        public UserLevelOne()
        {
            InitializeComponent();
            MoveBall = RebounceBall;
            MoveBall += Start_Move_Ball;
        }

        // Metodos que coinciden con el delegate de Event
        private void UserLevelOne_Load(object sender, EventArgs e)
        {
            // Seteando los atributos para picBox jugador
            picPlayerBar.BackgroundImage = Image.FromFile("../../Resources/Bar.png");
            picPlayerBar.BackgroundImageLayout = ImageLayout.Stretch;

            picPlayerBar.Top = Height - picPlayerBar.Height - 80;
            picPlayerBar.Left = (Width / 2) - (picPlayerBar.Width / 2);

            // Seteando los atributos para picBox pelota
            ball = new PictureBox();
            ball.Width = ball.Height = 40;
            ball.BackgroundImage = Image.FromFile("../../Resources/Ball.png");
            ball.BackgroundImageLayout = ImageLayout.Stretch;

            ball.Top = picPlayerBar.Top - ball.Height;
            ball.Left = picPlayerBar.Left + (picPlayerBar.Width / 2) - (ball.Width / 2);

            Controls.Add(ball);

            LoadTiles();
            timer1.Start();
        }

        private void LoadTiles()
        {
            int xAxis = 10, yAxis = 5;

            int pbWidth = (Width - (xAxis - 5)) / xAxis;
            int pbHeight = (int)(Height * 0.3) / yAxis;

            cpb = new CustomPictureBox[yAxis, xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    cpb[i, j] = new CustomPictureBox();

                    if (i == 0)
                        cpb[i, j].Hits = 2;
                    else
                        cpb[i, j].Hits = 1;

                    cpb[i, j].Height = pbHeight;
                    cpb[i, j].Width = pbWidth;

                    // Posicion de left, y posicion de top
                    cpb[i, j].Left = j * pbWidth;
                    cpb[i, j].Top = i * pbHeight;

                    cpb[i, j].BackgroundImage = Image.FromFile("../../Resources/block.jpg");
                    cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;

                    cpb[i, j].Tag = "tileTag";

                    Controls.Add(cpb[i, j]);
                }
            }
        }

        private int GRN()
        {
            return new Random().Next(1, 8);
        }

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

        private void UserLevelOne_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                DataGame.GameStart = true;
        }

        private void RebounceBall()
        {
            if (ball.Bottom > Height)
            {
                timer1.Stop();
                EndGame?.Invoke();
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

            for (int i = 4; i >= 0; i--)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (cpb[i, j] != null && ball.Bounds.IntersectsWith(cpb[i, j].Bounds))
                    {
                        cpb[i, j].Hits--;

                        if (cpb[i, j].Hits == 0)
                        {
                            Controls.Remove(cpb[i, j]);
                            cpb[i, j] = null;
                        }

                        DataGame.dirY = -DataGame.dirY;

                        return;
                    }
                }
            }
        }

        private void Start_Move_Ball()
        {
            ball.Left += DataGame.dirX;
            ball.Top += DataGame.dirY;
        }

        /*
        private void UserLevelOne_Load(object sender, EventArgs e)
        {
            picPlayerBar.BackgroundImage = Image.FromFile("../../Resources/Bar.png");
            picPlayerBar.BackgroundImageLayout = ImageLayout.Stretch;

            picPlayerBar.Top = Height - picPlayerBar.Height - 80;
            picPlayerBar.Left = (Width / 2) - (picPlayerBar.Width / 2);

            ball = new PictureBox();
            ball.Width = ball.Height = 40;
            ball.BackgroundImage = Image.FromFile("../../Resources/Ball.png");
            ball.BackgroundImageLayout = ImageLayout.Stretch;

            ball.Top = picPlayerBar.Top - ball.Height;
            ball.Left = picPlayerBar.Left + (picPlayerBar.Width / 2) - (ball.Width / 2);

            Controls.Add(ball);

            LoadTiles();
            timer1.Start();
        }
        private void LoadTiles()
        {
            int xAxis = 10;
            int yAxis = 5;

            int pbHeight = (int)(Height * 0.3) / yAxis;
            int pbWidth = (Width - (xAxis - 5)) / xAxis;

            cpb = new CustomPictureBox[yAxis, xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    cpb[i, j] = new CustomPictureBox();

                    if (i == 0)
                        cpb[i, j].Hits = 2;
                    else
                        cpb[i, j].Hits = 1;

                    cpb[i, j].Height = pbHeight;
                    cpb[i, j].Width = pbWidth;

                    // Posicion de left, y posicion de top
                    cpb[i, j].Left = j * pbWidth;
                    cpb[i, j].Top = i * pbHeight;

                    // Si el valor de i = 0, entonces colocar ruta de imagen de bloque blindado
                    cpb[i, j].BackgroundImage = Image.FromFile("../../Resources/block.jpg");
                    cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;

                    cpb[i, j].Tag = "tileTag";

                    Controls.Add(cpb[i, j]);
                }
            }
        }
        //esto es para poner las imagenes de los bloques al azar 
        //por el momento solo estamos poniendo de un bloque para ir probando
        private int GRN()
        {
            return new Random().Next(1, 8);
        }
        

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!DataGame.GameStart)
                return;

            ball.Left += DataGame.dirX;
            ball.Top += DataGame.dirY;

            rebotarPelota();
        }

        private void UserLevelOne_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                DataGame.GameStart = true;
        }

        private void rebotarPelota()
        {
            if (ball.Bottom > Height)
                Application.Exit();

            if (ball.Left < 0 || ball.Right > Width)
            {
                DataGame.dirX = -DataGame.dirX;
                return;
            }

            if (ball.Bounds.IntersectsWith(picPlayerBar.Bounds))
            {
                DataGame.dirY = -DataGame.dirY;
            }


            for (int i = 4; i >= 0; i--)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (ball.Bounds.IntersectsWith(cpb[i, j].Bounds))
                    {
                        cpb[i, j].Hits--;

                        if (cpb[i, j].Hits == 0)
                            Controls.Remove(cpb[i, j]);

                        DataGame.dirY = -DataGame.dirY;

                        return;
                    }
                }
            }
        }*/
    }
}
