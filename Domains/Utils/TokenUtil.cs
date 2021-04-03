using FatecMauaJobNewsletter.Domains.Claims;
using FatecMauaJobNewsletter.Domains.Enums;
using FatecMauaJobNewsletter.Domains.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FatecMauaJobNewsletter.Domains.Utils
{
    public static class TokenUtil
    {
        public static string GenerateTokenJWT(User userRegister, IConfiguration configuration)
        {
            Claim roleClaim;

            if (userRegister.UserType.Equals(UserType.Administration))
                roleClaim = new Claim(ClaimTypes.Role, UserClaim.Administration);
            else
                roleClaim = new Claim(ClaimTypes.Role, UserClaim.Student);

            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Issuer = configuration["Jwt:Issuer"],
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, userRegister.Email),
                    new Claim(ClaimTypes.Name, userRegister.Name),
                    new Claim(ClaimTypes.NameIdentifier, userRegister.Login),
                    roleClaim
                })
            };

            var tokenhandler = new JwtSecurityTokenHandler();
            var token = tokenhandler.CreateToken(tokenDescriptor);
            return tokenhandler.WriteToken(token);
        }
    }
}
