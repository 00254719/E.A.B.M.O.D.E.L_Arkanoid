using System;
using System.Windows.Forms;

namespace Proyecto_Final.Vista
{
    public partial class frmLevel : Form
    {

        bool goRight;
        bool goLeft;

        int Ball_X = 0;
        int Ball_Y = 0;
        int Score = 0;
        int playerSpeed = 0;
        


        Random rnd = new Random();
        private void SetupGame()
        {
             Ball_X = 6; 
             Ball_Y = 6;
             Score = 0;
             playerSpeed = 12;

            tmrBall.Start(); 



        }
        public frmLevel()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Height = Screen.PrimaryScreen.Bounds.Height;
            Width = Screen.PrimaryScreen.Bounds.Width;
            SetupGame(); 

        }
        private void Game_Over()
        {
            if(Score > 38)
            {
                tmrBall.Stop();
                MessageBox.Show("Ha Ganadooooooooo.....");
            }
            if (Ball.Top+Ball.Height > ClientSize.Height)
            {
                tmrBall.Stop();
                MessageBox.Show("Ha Perdido");
            }
          
        }

        private void Get_Score()
        {
            foreach(Control X in Controls)
            {
                if( X is PictureBox && X.Tag == "BlockGreen")
                {
                    if (Ball.Bounds.IntersectsWith(X.Bounds))
                    {
                        Controls.Remove(X);
                        Ball_Y = -Ball_Y;
                        Score++;
                        label1.Text = "Score : " + Score;
                    }
                }
                if (X is PictureBox && X.Tag == "BlockYellow")
                {
                    if (Ball.Bounds.IntersectsWith(X.Bounds))
                    {
                        Controls.Remove(X);
                        Ball_Y = -Ball_Y;
                        Score++;
                        label1.Text = "Score : " + Score;
                    }
                }
                if (X is PictureBox && X.Tag == "BlockViolet")
                {
                    if (Ball.Bounds.IntersectsWith(X.Bounds))
                    {
                        Controls.Remove(X);
                        Ball_Y = -Ball_Y;
                        Score++;
                        label1.Text = "Score : " + Score;
                    }
                }
                if (X is PictureBox && X.Tag == "BlockBlue")
                {
                    if (Ball.Bounds.IntersectsWith(X.Bounds))
                    {
                        Controls.Remove(X);
                        Ball_Y = -Ball_Y;
                        Score++;
                        label1.Text = "Score : " + Score;
                    }
                }
                
                if (X is PictureBox && X.Tag == "BlockIron")
                {
                    if (Ball.Bounds.IntersectsWith(X.Bounds))
                    {
                        
                        Ball_Y = -Ball_Y;
                        label1.Text = "Score : " + Score;
                    }
                }

                if (X is PictureBox && X.Tag == "BlockRed")
                {
                    if (Ball.Bounds.IntersectsWith(X.Bounds))
                    {
                        Controls.Remove(X);
                        Ball_Y = -Ball_Y;
                        Score++;
                        label1.Text = "Score : " + Score;
                    }
                }
            }
        }

        private void Ball_Movment()
        {
           
            
            if(Ball.Left+Ball.Width > ClientSize.Width || Ball.Left < 0)
            {
                Ball_X = -Ball_X;
            }
            if(Ball.Top < 0 || Ball.Bounds.IntersectsWith(picBounceBar.Bounds))
            {
                Ball_Y = rnd.Next(5, 12) * -1;
            } 
            
            if(Ball.Top < 0 || Ball.Bounds.IntersectsWith(pbxGreen.Bounds) || Ball.Bounds.IntersectsWith(pbxYellow.Bounds) 
                || Ball.Bounds.IntersectsWith(pbxViolet.Bounds) || Ball.Bounds.IntersectsWith(pbxBlue.Bounds) 
                || Ball.Bounds.IntersectsWith(pbxRed.Bounds) || Ball.Bounds.IntersectsWith(pxbIron.Bounds))
            {
                Ball_Y = -Ball_Y;
            }
        }

        private void frmLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left && picBounceBar.Left > 0)
            {
                goLeft = true;
                DoubleBuffered = true;
            }
            if (e.KeyCode == Keys.Right && picBounceBar.Right < 1431)
            {
                goRight = true;
                DoubleBuffered = true;

            }
        }

        private void frmLevel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false ;
                DoubleBuffered = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
                DoubleBuffered = true;

            }
        }

        private void BallCollision()
        {
            if (goLeft == true && picBounceBar.Left > 0)
            {
                picBounceBar.Left -= playerSpeed;
            }

            if (goRight == true && picBounceBar.Left < 1431)
            {
                picBounceBar.Left += playerSpeed;
            }

            Ball.Left += Ball_X;
            Ball.Top += Ball_Y;
        }
        private void tmrBall_Tick(object sender, EventArgs e)
        {
           
            Ball_Movment();
            Get_Score();
            Game_Over();
            BallCollision();
         

        }
    }

    }

