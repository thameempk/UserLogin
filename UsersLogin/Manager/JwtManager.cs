using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsersLogin.Manager.Interface;
using UsersLogin.Models;

namespace UsersLogin.Manager
{
    public class JwtManager : IJwtManager
    {
        private readonly IConfiguration configuration;
        public JwtManager(IConfiguration configuration)
        {
            this.configuration = configuration; 
        }
        public async Task<string> JwtToken(Users user)
        {
            if (user == null)
            {
                return "invalid user";
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName)
        };

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddHours(1)

            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}

