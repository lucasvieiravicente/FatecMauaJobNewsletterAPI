using FatecMauaJobNewsletter.Domains.Claims;
using FatecMauaJobNewsletter.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace FatecMauaJobNewsletter.Services
{
    public class CookiesService : ICookiesService
    {
        private readonly IHttpContextAccessor _httpContext;

        public CookiesService(IHttpContextAccessor httpContextAccessor) 
        {
            _httpContext = httpContextAccessor;
        }

        public bool IsAdmin()
        {
            return _httpContext.HttpContext.User.Claims.Any(x => x.Type == ClaimTypes.Role && x.Value == UserClaim.Administration);
        }

        public bool IsLogged()
        {
            return _httpContext.HttpContext.User.Claims?.Any() ?? false;
        }
    }
}
