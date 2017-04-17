using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using Capstone.Web.DAL;

namespace Capstone.Web.Models
{
    public class Tournament 
    {
        private readonly string connectionString = @"Data Source=DESKTOP-58F8CH1\SQLEXPRESS;Initial Catalog=CapstoneDB;Integrated Security=True";
        private ITournamentDAL tournamentDal;
        public  List<Tournament> GetAllTournaments()
        {
            tournamentDal = new TournamentSqlDal(connectionString);
            return tournamentDal.getAllTournaments();
        }
        public int TournamentId { get; set; }

        public List<User> UserList { get; set; }

        [Required(ErrorMessage ="Tournament Name is required")]
        public string TournamentName { get; set; }

        public int OrganizerId { get; set; }
        public string OrganizerName { get; set; }

        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "# of Competitors is required")]
        public int CompetitorLimit { get; set; }
        public string GameName { get; set; }
        public string GameType { get; set; }
        public string GameStatus { get; set; }

        public string SearchTerm { get; set; }

        int[] brackets;
       

        public int[] Brackets
        {
            get { return brackets; }
            set { brackets = value; }
        }  

        public int[] GenerateFirstBracket(int totalPlayers)
        {
            int[] array = new int[totalPlayers];
            
            //assign initial numbers to the array
            int[] playerArray = new int[totalPlayers];
            int[] arr1 = new int[totalPlayers / 2];
            int[] arr2 = new int[totalPlayers / 2];

            int half = (totalPlayers / 2);

            for (int i = 0; i < totalPlayers; i++)
            {
                playerArray[i] = i + 1;
            }
            for(int i = 0; i < half; i++)
            {
                arr1[i] = playerArray[half - 1-i];
                arr2[i] = playerArray[totalPlayers - 1 - i];
            }
            array = arr1.Concat(arr2).ToArray();
            return array;
        }

    }
}