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
        private const string getAllTournamentsSql = "SELECT [tournament_id] ,[tournament_name],[organizer_id],[start_date],[end_date],"
                                    + "[competitor_limit],[game],[status],[type],[displayname] FROM tournaments JOIN users ON user_id = organizer_id ORDER BY tournament_name;";

        private string getATournamentSql = "SELECT * FROM tournaments WHERE tournament_id = @tournament_id";
        private string sqlCommandGetTournamentByName = "SELECT * FROM tournaments JOIN users ON tournament_id = user_id WHERE tournament_name LIKE '%' + @searchTerm + '%';";

        public TournamentSqlDal(string connectionString)
        {
            databaseConnectionString = connectionString;
        }

        public List<Tournament> GetTournamentByName(string searchTerm)
        {
            List<Tournament> list = new List<Tournament>();
            try
            {
                using (SqlConnection conn = new SqlConnection(databaseConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlCommandGetTournamentByName, conn);
                    
                    command.Parameters.AddWithValue("@searchTerm", searchTerm);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Tournament t = new Tournament();

                        t.TournamentId = Convert.ToInt32(reader["tournament_id"]);
                        t.TournamentName = Convert.ToString(reader["tournament_name"]);
                        t.GameName = Convert.ToString(reader["game"]);
                        t.GameType = Convert.ToString(reader["type"]);
                        t.OrganizerId = Convert.ToInt32(reader["organizer_id"]);
                        t.OrganizerName = Convert.ToString(reader["displayname"]);
                        t.StartDate = Convert.ToDateTime(reader["start_date"]);
                        t.EndDate = Convert.ToDateTime(reader["end_date"]);
                        t.GameStatus = Convert.ToString(reader["status"]);
                        t.CompetitorLimit = Convert.ToInt32(reader["competitor_limit"]);

                        list.Add(t);
                    }
                }
                return list;
            }
            catch (Exception exception)
            {
                throw exception;
            }
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

                        t.TournamentId = Convert.ToInt32(reader["tournament_id"]);
                        t.TournamentName = Convert.ToString(reader["tournament_name"]);
                        t.GameName = Convert.ToString(reader["game"]);
                        t.GameType = Convert.ToString(reader["type"]);
                        t.OrganizerId = Convert.ToInt32(reader["organizer_id"]);
                        t.OrganizerName = Convert.ToString(reader["displayname"]);
                        t.StartDate = Convert.ToDateTime(reader["start_date"]);
                        t.EndDate = Convert.ToDateTime(reader["end_date"]);
                        t.GameStatus = Convert.ToString(reader["status"]);
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
                using (SqlConnection conn = new SqlConnection(databaseConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getATournamentSql, conn);
                    cmd.Parameters.AddWithValue("@tournament_id", tournament_id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Tournament t = new Tournament();

                        t.TournamentId = Convert.ToInt32(reader["tournament_id"]);
                        t.TournamentName = Convert.ToString(reader["tournament_name"]);
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
