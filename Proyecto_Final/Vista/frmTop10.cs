using Proyecto_Final.Controlador;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Final.Vista
{
    public partial class frmTop10 : Form
    {
        private Label[,] players;

        public frmTop10()
        {
            InitializeComponent();
        }

        // Cambiar entre ventanas actuales a traves del delegate

        private void LoadPlayers()
        {
            var playersList = Player_DAO.QueryPlayerTop();
            players = new Label[10, 2];

            int sampleTop = label1.Bottom + 25, sampleLeft = 35;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    players[i, j] = new Label();

                    if (j == 0)
                    {
                        players[i, j].Text = playersList[i].Nickname;
                        players[i, j].Left = sampleLeft;
                    }
                    else
                    {
                        players[i, j].Text = playersList[i].Score.ToString();
                        players[i, j].Left = Width / 2 + sampleLeft;
                    }

                    players[i, j].Top = sampleTop + 45 * i;

                    players[i, j].Height += 4;
                    players[i, j].Width += 30;

                    players[i, j].Font = new Font("Barcade No Bar Bold", 18F);
                    players[i, j].ForeColor = System.Drawing.Color.White;
                    players[i, j].BackColor = System.Drawing.Color.Transparent;
                    players[i, j].TextAlign = ContentAlignment.MiddleCenter;

                    Controls.Add(players[i, j]);
                }
            }
        }

        private void frmTop10_Load(object sender, EventArgs e)
        {
            LoadPlayers();
        }
    }
}

