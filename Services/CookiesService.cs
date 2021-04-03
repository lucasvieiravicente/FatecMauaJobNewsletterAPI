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
        private const string jwtCookieName = "bearerJwt";

        public CookiesService(IHttpContextAccessor httpContextAccessor) 
        {
            _httpContext = httpContextAccessor;
        }

        public void SetLoginCookie(string jwtToken)
        {
            _httpContext.HttpContext.Response.Cookies.Append(jwtCookieName, jwtToken);
        }

        public void RemoveLoginCookie()
        {
            _httpContext.HttpContext.Response.Cookies.Delete(jwtCookieName);
        }

        public bool IsAdmin()
        {
            return _httpContext.HttpContext.User.Claims.Any(x => x.Type == ClaimTypes.Role && x.Value == UserClaim.Administration);
        }

        public bool IsLogged()
        {
            return _httpContext.HttpContext.Request.Cookies?.Any(x => x.Key == jwtCookieName) ?? false;
        }

        public string GetJwtToken()
        {
            return _httpContext.HttpContext.Request.Cookies?.FirstOrDefault(x => x.Key == jwtCookieName).Value;
        }
    }
}
