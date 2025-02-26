using web.Service.IServices;
using web.Utility;

namespace web.Service.Services
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public TokenProvider(IHttpContextAccessor httpContextAccessor) 
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public void ClearToken()
        {
            httpContextAccessor.HttpContext?.Response.Cookies.Delete(SD.TokenCookies);
        }

        public string? GetToken()
        {
            string? token = null;
            bool? hasToken = httpContextAccessor.HttpContext?.Request.Cookies.TryGetValue(SD.TokenCookies, out token);
            return hasToken is true ? token : null;
        }

        public void SetToken(string token)
        {
            httpContextAccessor.HttpContext?.Response.Cookies.Append(SD.TokenCookies, token);
        }
    }
}
