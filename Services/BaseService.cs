using FatecMauaJobNewsletter.Domains.Claims;
using FatecMauaJobNewsletter.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Services
{
    public abstract class BaseService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAdmin()
        {
            IEnumerable<Claim> claims = _httpContextAccessor.HttpContext.User.Claims;
            string userType = claims.Where(x => x.Type == ClaimType.UserType)
                                    .Select(x => x.Value)
                                    .FirstOrDefault();

            return userType.Equals(UserClaim.Administration);
        }

        public string GetUser()
        {
            IEnumerable<Claim> claims = _httpContextAccessor.HttpContext.User.Claims;
            return claims.Where(x => x.Type == ClaimType.Login)
                         .Select(x => x.Value)
                         .FirstOrDefault();
        }

        public string GetUserEmail()
        {
            IEnumerable<Claim> claims = _httpContextAccessor.HttpContext.User.Claims;
            return claims.Where(x => x.Type == ClaimType.Email)
                         .Select(x => x.Value)
                         .FirstOrDefault();
        }
    }
}
