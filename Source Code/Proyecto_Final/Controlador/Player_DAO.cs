using Proyecto_Final.Modelo;
using System;
using System.Collections.Generic;
using System.Data;

namespace Proyecto_Final.Controlador
{
    public static class Player_DAO
    {
        // Consultar el Id de un jugador
        public static int QueryIdplayer(string nick)
        {
            var dt = ConnectionDB.ExecuteQuery($"SELECT idPlayer FROM PLAYER WHERE nickname = '{nick}'");
            DataRow idaux = dt.Rows[0];
            int idplayer = Convert.ToInt32(idaux[0].ToString());

            return idplayer;
        }

        // Ingresar un nuevo jugador
        public static bool CreatePlayer(string nickname)
        {
            var dt = ConnectionDB.ExecuteQuery($"SELECT * FROM PLAYER WHERE nickname = '{nickname}'");

            if (dt.Rows.Count > 0)
                return true;
            else
            {
                ConnectionDB.ExecuteNonQuery("INSERT INTO PLAYER(nickname) VALUES" +
                    $"('{nickname}')");

                return false;
            }
        }

        // Guardar el Score de un jugador
        public static void CreateNewScore(int idPlayer, int score)
        {
            ConnectionDB.ExecuteNonQuery("INSERT INTO SCORE(idPlayer, score) VALUES" +
                $"({idPlayer}, {score})");
        }

        //Consultar y guardar en una lista el top 10
        public static List<Player> QueryPlayerTop()
        {
            var topPlayers = new List<Player>();
            DataTable dt = ConnectionDB.ExecuteQuery("SELECT pl.nickname, sc.score " +
                                                    "FROM PLAYER pl, SCORE sc " +
                                                    "WHERE pl.idPlayer = sc.idPlayer " +
                                                    "ORDER BY sc.score DESC " +
                                                    "LIMIT 10");

            foreach (DataRow dr in dt.Rows)
            {
                topPlayers.Add(new Player(dr[0].ToString(), Convert.ToInt32(dr[1])));
            }

            return topPlayers;
        }
    }
}
