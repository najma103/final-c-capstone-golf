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
        public List<Tournament> GetAllTournaments()
        {
            TournamentSqlDal DAL = new TournamentSqlDal();
            return DAL.GetAllTournaments();
        }

        [Required(ErrorMessage = "This field is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string Name { get; set; }

        public int OrganizerId { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "This field is required")]
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
            double rounds = Math.Log(totalPlayers) / Math.Log(2) - 1;
            //assign initial numbers to the array
            int[] playerArray = new int[totalPlayers];
            int[] arr1 = new int[totalPlayers / 2];
            int[] arr2 = new int[totalPlayers / 2];

            int half = totalPlayers / 2;

            for (int i = 0; i < totalPlayers; i++)
            {
                playerArray[i] = i + 1;
            }
            for(int i = 0; i < half; i++)
            {
                arr1[i] = playerArray[half - i];
                arr2[i] = playerArray[totalPlayers - 1 - i];
            }
            array = arr1.Concat(arr2).ToArray();
            return array;
        }
        //public int[] nextLayer(int[] arr, int size)
        //{
        //    int[] outArr = new int[size];
        //    int length = (arr.Length * 2 + 1);

        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        outArr[i] = arr[i];
        //        outArr[i] = arr[length - arr[i]];
        //    }
        //    return outArr;
        //}

    }
}