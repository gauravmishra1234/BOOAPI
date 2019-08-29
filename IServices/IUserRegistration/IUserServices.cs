using BOOAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOAPI.IServices
{
    public interface IUserServices
    {
        User GetValidateUser(string username, string password);
    }
}
