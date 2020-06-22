namespace Proyecto_Final.Modelo
{
    public class Player
    {
        public string Nickname { get; set; }
        public int Score { get; set; }

        public Player(string nickname, int score)
        {
            this.Nickname = nickname;
            this.Score = score;
        }
    }
}
