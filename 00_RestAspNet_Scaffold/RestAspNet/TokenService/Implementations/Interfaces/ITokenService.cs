using System.Collections.Generic;
using System.Security.Claims;

namespace RestAspNet.TokenService.Implementations.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateUpdateToken();
        ClaimsPrincipal GerPrincipalFromExpiredToken(string token);
    }
}