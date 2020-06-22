
namespace Proyecto_Final.Controlador
{
    public static class DataGame
    {
        public static bool GameStart = false;
        public static int dirX = 10, dirY = -dirX, lifes = 3, score = 0;

        public static void InicializateGame()
        {
            GameStart = false;
            lifes = 3;
            score = 0;
        }
    }
}
