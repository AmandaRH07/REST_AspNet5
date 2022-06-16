using System.Collections.Generic;
using System.Security.Claims;

namespace RestAspNet.TokenService
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateUpdateToken();
        ClaimsPrincipal GerPrincipalFromExpiredToken(string token);
        
    }
}
