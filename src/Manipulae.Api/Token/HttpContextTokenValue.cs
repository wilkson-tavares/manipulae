using Manipulae.Domain.Interface.Security.Tokens;

namespace Manipulae.Api.Token
{
    /// <summary>
    /// Returns the token
    /// </summary>
    public class HttpContextTokenValue : ITokenProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public HttpContextTokenValue(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Returns the token regarding logged user
        /// </summary>
        /// <returns></returns>
        public string TokenOnRequest()
        {
            var authorization = _contextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

            return authorization["Bearer ".Length..].Trim();
        }
    }
}
