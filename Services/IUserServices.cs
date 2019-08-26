using BOOAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOAPI.Services
{
    public interface IUserServices
    {
        User Authenticate(string username, string password);
    }
}
