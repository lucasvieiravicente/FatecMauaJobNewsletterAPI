using FatecMauaJobNewsletter.Domains.Claims;
using FatecMauaJobNewsletter.Domains.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FatecMauaJobNewsletter.Domains.Utils
{
    public static class TokenUtil
    {
        public static string GenerateTokenJWT(User userRegister)
        {
            var config = Startup.StaticConfiguration;

            string issuer = config["Jwt:Issuer"];
            string audience = config["Jwt:Audience"];
            DateTime expires = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = GetUserClaims(userRegister);

            var token = new JwtSecurityToken(issuer, audience, claims, null, expires, credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);            
        }

        private static List<Claim> GetUserClaims(User user)
        {
            string userClaim;
            if (user.UserType.Equals(UserType.Administration))
                userClaim = UserClaim.Administration;
            else
                userClaim = UserClaim.Student;

            return new List<Claim>
            {
                new Claim(ClaimType.Email, user.Email),
                new Claim(ClaimType.Login, user.Login),
                new Claim(ClaimType.UserType, userClaim)
            };
        }
    }
}
