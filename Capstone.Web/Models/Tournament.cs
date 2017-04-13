using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
using Capstone.Web.DAL;
=======
>>>>>>> 8dd9874c774926f1ee1a0363f644828655015107

namespace Capstone.Web.Models
{
    public class Tournament 
    {
<<<<<<< HEAD
        private readonly string connectionString = @"Data Source=desktop-58f8ch1\sqlexpress;Initial Catalog=Capstone;Integrated Security=True";
        private ITournamentDAL tournamentDal;
        public  List<Tournament> GetAllTournaments()
        {
            tournamentDal = new TournamentSqlDal(connectionString);
            return tournamentDal.getAllTournaments();
        }
=======
        public int TournamentId { get; set; }
>>>>>>> 8dd9874c774926f1ee1a0363f644828655015107

        public List<User> UserList { get; set; }

        public string TournamentName { get; set; }

        public int OrganizerId { get; set; }

        public DateTime StartDate { get; set; }

<<<<<<< HEAD
        [Required(ErrorMessage = "End date is required")]
=======
>>>>>>> 8dd9874c774926f1ee1a0363f644828655015107
        public DateTime EndDate { get; set; }

        public int CompetitorLimit { get; set; }

         int[] brackets;
       

        public int[] Brackets
        {
            get { return brackets; }
            set { brackets = value; }
        }  

        public int[] GenerataFirstBracket(int totalPlayers)
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