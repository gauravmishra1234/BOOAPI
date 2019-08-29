using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOOAPI.IServices;
using BOOAPI.Models;
using BOOAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOOAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUserServices _userServices;
        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public User GetValidate(string userName, string password)
        {
            var user = _userServices.GetValidateUser(userName, password);

            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }
    }
}