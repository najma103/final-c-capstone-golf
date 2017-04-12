using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class MatchesSqlDal
    {
        private string connectionString = @"Data Source=desktop-58f8ch1\sqlexpress;Initial Catalog=Capstone;Integrated Security=True";
        private const string getAllMatchesSql =
            @"select m.match_id, m.user1_id, m.user2_id, t.tournament_id,
                t.tournament_name from matches AS m 
            INNER JOIN tournaments AS t ON m.tournament_id = t.tournament_id
            INNER JOIN tournament_competitors AS tc on m.user1_id = tc.competitor_id OR m.user2_id = tc.competitor_id
            INNER JOIN users as u ON u.user_id = tc.competitor_id;";

        public List<Match> getAllMatches()
        {
            List<Match> listOfMatches = new List<Match>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(getAllMatchesSql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Match match = new Match();

                        match.MatchId = Convert.ToInt32(reader["m.match_id"]);
                        match.PlayerA = Convert.ToInt32(reader["m.user1_id"]);
                        match.PlayerB = Convert.ToInt32(reader["m.user2_id"]);
                        match.TournamentId = Convert.ToInt32(reader["t.tournament_id"]);
                        match.TournamentName = Convert.ToString(reader["t.tournament_name"]);

                        listOfMatches.Add(match);
                    }
                }
                return listOfMatches;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


    }
}