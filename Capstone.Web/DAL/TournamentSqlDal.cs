using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class TournamentSqlDal : ITournamentDAL
    {
        private readonly string databaseConnectionString;
        private const string getAllTournamentsSql = "SELECT * FROM tournaments order by tournament_name";

        public TournamentSqlDal(string connectionString)
        {
            databaseConnectionString = connectionString;
        }

        public List<Tournament> getAllTournaments()
        {
            List<Tournament> listOfTourtnaments = new List<Tournament>();
            try
            {
                using (SqlConnection conn = new SqlConnection(databaseConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(getAllTournamentsSql , conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Tournament t = new Tournament();

                        t.Id = Convert.ToInt32(reader["tournament_id"]);
                        t.Name = Convert.ToString(reader["tournament_name"]);
                        t.OrganizerId = Convert.ToInt32(reader["organizer_id"]);
                        t.StartDate = Convert.ToDateTime(reader["start_date"]);
                        t.EndDate = Convert.ToDateTime(reader["end_date"]);
                        t.CompetitorLimit = Convert.ToInt32(reader["competitor_limit"]);  

                        listOfTourtnaments.Add(t);
                    } 
                }
                return listOfTourtnaments;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Tournament getATournament(int tournament_id)
        {
            Tournament tempTournament = new Tournament();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getATournamentSql, conn);
                    cmd.Parameters.AddWithValue("@tournament_id", tournament_id);

                    SqlCommand command = new SqlCommand(getATournamentSql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Tournament t = new Tournament();

                        t.Id = Convert.ToInt32(reader["tournament_id"]);
                        t.Name = Convert.ToString(reader["tournament_name"]);
                        t.OrganizerId = Convert.ToInt32(reader["organizer_id"]);
                        t.StartDate = Convert.ToDateTime(reader["start_date"]);
                        t.EndDate = Convert.ToDateTime(reader["end_date"]);
                        t.CompetitorLimit = Convert.ToInt32(reader["competitor_limit"]);

                        tempTournament = t;
                    }
                }
                return tempTournament;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

    }
}
