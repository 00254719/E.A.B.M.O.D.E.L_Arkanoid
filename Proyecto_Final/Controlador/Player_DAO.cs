using Proyecto_Final.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Controlador
{
    public static class Player_DAO
    {
        //Consultar y guardar en una lista todos los jugadores
        public static List<Player> PlayerList()
        {
            List<Player> PlayersList = new List<Player>();

            String query = "SELECT NICKNAME, SCORE FROM PLAYER";
            DataTable dt = ConnectionDB.ExecuteQuery(query);

            foreach (DataRow dr in dt.Rows)
            {
                Player p = new Player();
                p.Nickname = dr[0].ToString();
                p.Score = Convert.ToInt32(dr[1].ToString());

                PlayersList.Add(p);
            }

            return PlayersList;
        }

        //Consultar y guardar en una lista el top 10
        public static List<Player> Top10PlayerList()
        {
            List<Player> PlayersList = new List<Player>();

            String query = "SELECT * FROM PLAYER ORDER BY SCORE DESC" +
                " FETCH FIRST 10 ROWS ONLY";
            DataTable dt = ConnectionDB.ExecuteQuery(query);

            foreach (DataRow dr in dt.Rows)
            {
                Player p = new Player();
                p.Nickname = dr[0].ToString();
                p.Score = Convert.ToInt32(dr[1].ToString());

                PlayersList.Add(p);
            }

            return PlayersList;
        }

        // Ingresar un nuevo jugador
        public static void AddPlayer(string nick)
        {
            String cmd = String.Format("INSERT INTO public.player(nickname, score)" +
                  "	VALUES('{0}', 0); ", nick);
            ConnectionDB.ExecuteNonQuery(cmd);
        }        
    }
}
