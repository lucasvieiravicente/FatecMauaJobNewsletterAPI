using FatecMauaJobNewsletter.Domains.Claims;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

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
            return _httpContextAccessor.HttpContext.User.Claims.Any(x => x.Type == ClaimTypes.Role && x.Value == UserClaim.Administration);
        }

        public string GetLogin()
        {
            var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            return claim?.Value ?? "Usuário não autenticado";
        }

        public string GetEmail()
        {
            var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            return claim?.Value ?? "Usuário sem e-mail";
        }

        public string GetName()
        {
            var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
            return claim.Value ?? "Usuário não autenticado";
        }
    }
}
