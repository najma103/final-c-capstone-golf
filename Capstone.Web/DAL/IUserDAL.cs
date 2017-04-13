using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface IUserDAL
    {
        bool CreateUser(User newUser);

        bool ChangePassword(string username, string newPassword);

        User GetUser(string username);
    }
}
