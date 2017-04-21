using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class BracketSqlDal
    {
        private string connectionString = @"Data Source=DESKTOP-58F8CH1\SQLEXPRESS;Initial Catalog=Capstone;Integrated Security=True";
        private string sqlGetByTourId = @"select * from brackets where tournament_id = @tournamentId";
        public List<Bracket> GetBracketByTourId(int tournamenetId)
        {

            List<Bracket> list = new List<Bracket>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlGetByTourId, conn);

                    command.Parameters.AddWithValue("@tournamentId", tournamenetId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Bracket bracket = new Bracket();

                        bracket.bracketId = Convert.ToInt32(reader["bracket_id"]);
                        bracket.playerName = Convert.ToString(reader["player_name"]);
                        bracket.Score = Convert.ToInt32(reader["br_score"]);

                        list.Add(bracket);
                    }
                }
                return list;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}