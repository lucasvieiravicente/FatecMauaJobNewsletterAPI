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
            List<Claim> claims = new List<Claim>();

            if (userRegister.UserType.Equals(UserType.Administration))
                claims.Add(new Claim("UserType", UserClaim.Administration));
            else
                claims.Add(new Claim("UserType", UserClaim.Student));

            var token = new JwtSecurityToken(issuer, audience, claims, null, expires, credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);            
        }
    }
}
