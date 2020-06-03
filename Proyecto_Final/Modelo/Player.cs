using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Modelo
{
    public class Player
    {
        public string nickname { get; set; }
        public int score { get; set; }

        public Player(string nickname = "", int score = 0)
        {
            this.nickname = nickname;
            this.score = score;
        }
    }
}
