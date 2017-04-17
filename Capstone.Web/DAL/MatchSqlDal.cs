using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class MatchSqlDal
    {
        private string connectionString = @"Data Source=desktop-58f8ch1\sqlexpress;Initial Catalog=Capstone;Integrated Security=True";
        private const string getTournamentMatchesSql = "SELECT * FROM matches where tournament_id = @tournamentId;";
        public List<Match> getTournamentMatches(int tournamentId)
        {
            List<Match> tempMatch = new List<Match>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(getTournamentMatchesSql, conn);
                    cmd.Parameters.AddWithValue("@tournamentId", tournamentId);

                    SqlCommand command = new SqlCommand(getTournamentMatchesSql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Match m = new Match();
                        m.MatchId = Convert.ToInt32(reader["match_id"]);
                        m.CompetitorId = Convert.ToInt32(reader["competitor_id"]);
                        m.TournamentId = Convert.ToInt32(reader["tournament_id"]);
                        m.Tier = Convert.ToInt32(reader["tier"]);
                        m.Position = Convert.ToInt32(reader["position"]);

                        tempMatch.Add(m);
                    }
                }
                return tempMatch;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}