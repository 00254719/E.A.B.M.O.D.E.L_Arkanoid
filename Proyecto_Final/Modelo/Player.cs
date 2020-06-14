using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Modelo
{
    public class Player
    {
        public string Nickname { get; set; }
        public int Score { get; set; }

        public Player(string nickname = "", int score = 0)
        {
            this.Nickname = nickname;
            this.Score = score;
        }
    }
}
