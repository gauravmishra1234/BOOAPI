using UserAccount.Helpers;
using UserAccount.IServices;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using UserAccount.Models;
using Microsoft.Extensions.Options;

namespace UserAccount.Services
{
    public class UserServices : IUserServices
    {
        private readonly BooDevContext _context;
        private readonly AppSettings _appSettings;
        public UserServices(IOptions<AppSettings> appSettings, BooDevContext context)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public User GetValidateUser(string userName, string password)
        {
            var user = _context.User.SingleOrDefault(x => x.UserName == userName && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.RoleId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }
    }
}
