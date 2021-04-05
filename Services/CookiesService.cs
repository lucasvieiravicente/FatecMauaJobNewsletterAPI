using FatecMauaJobNewsletter.Domains.Claims;
using FatecMauaJobNewsletter.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace FatecMauaJobNewsletter.Services
{
    public class CookiesService : BaseService, ICookiesService
    {
        private readonly IHttpContextAccessor _httpContext;

        public CookiesService(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _httpContext = httpContextAccessor;
        }

        public bool IsLogged()
        {
            return _httpContext.HttpContext.User.Claims?.Any() ?? false;
        }
    }
}
