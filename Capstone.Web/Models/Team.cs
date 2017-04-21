using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Team
    {
        private List<string[]> matches = new List<string[]>();
        public List<string[]> teams { get; set; }

        public List<string[]> GetMatches(List<Bracket> list)
        {
            for (int i = 0; i < list.Count; i = i + 2)
            {
                string[] twoTeams = new string[2];
                twoTeams[0] = list[i].playerName;
                if (i < list.Count - 1)
                {
                    twoTeams[1] = list[i + 1].playerName;
                }
                matches.Add(twoTeams);
            }

            return matches;
        }
    }
}