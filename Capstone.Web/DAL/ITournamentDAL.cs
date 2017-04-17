using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface ITournamentDAL
    {
        List<Tournament> getAllTournaments();
        List<Tournament> GetTournamentByName(string searchTerm);
        Tournament getATournament(int tournamentId);
        bool addNewTournament(Tournament newTournament);
    }
}
