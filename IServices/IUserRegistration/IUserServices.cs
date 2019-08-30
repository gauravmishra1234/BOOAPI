using UserAccount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAccount.IServices
{
    public interface IUserServices
    {
        User GetValidateUser(string username, string password);
    }
}
