using System.Security.Claims;

namespace API.Utilities.Handlers
{
    public class TokenHandlerBase
    {
        public readonly IConfiguration Configuration;

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            throw new NotImplementedException();
        }
    }
}