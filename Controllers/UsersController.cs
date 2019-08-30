using UserAccount.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UserAccount.Models;

namespace UserAccount.Controllers
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

        [AllowAnonymous]
        [HttpPost]
        public IActionResult GetValidate([FromBody]User userParam)
        {
            var user = _userServices.GetValidateUser(userParam.UserName, userParam.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            else
            {
                return Ok(user);
            }
        }
    }
}