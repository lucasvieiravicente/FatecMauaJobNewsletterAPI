using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;

namespace FatecMauaJobNewsletter.Domains.Utils
{
    public class TokenUtil
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TokenUtil(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void DecodeTokenJWT()
        {
            _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues vs);

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(vs);
            var tokenS = handler.ReadToken(vs) as JwtSecurityToken;
        }
    }
}
