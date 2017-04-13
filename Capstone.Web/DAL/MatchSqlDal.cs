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
        private const string getTournamentMatchesSql = "SELECT * FROM matches where tournament_id = @tournament_id";


        public List<Match> getTournamentMatches(int tournament_id)
        {
            Match tempMatch = new Match();
            try
            {
                using (SqlConnection conn = new SqlConnection(getTournamentMatchesSql))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getTournamentMatchesSql, conn);
                    cmd.Parameters.AddWithValue("@tournament_id", tournament_id);

                    SqlCommand command = new SqlCommand(getTournamentMatchesSql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Tournament t = new Tournament();

                        t.Id = Convert.ToInt32(reader["match_id"]);
                        t.Name = Convert.ToString(reader["tournament_name"]);
                        t.OrganizerId = Convert.ToInt32(reader["organizer_id"]);
                        t.StartDate = Convert.ToDateTime(reader["start_date"]);
                        t.EndDate = Convert.ToDateTime(reader["end_date"]);
                        t.CompetitorLimit = Convert.ToInt32(reader["competitor_limit"]);

                        tempMatch = m;
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