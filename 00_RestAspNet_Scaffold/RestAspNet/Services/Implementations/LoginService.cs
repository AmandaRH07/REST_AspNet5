using RestAspNet.Configurations;
using RestAspNet.Data.Value_Object;
using RestAspNet.Model;
using RestAspNet.Repository;
using RestAspNet.TokenService.Implementations.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RestAspNet.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private const string _DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private readonly TokenConfiguration _tokenConfiguration;

        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginService(TokenConfiguration tokenConfiguration, IUserRepository userRepository, ITokenService tokenService)
        {
            _tokenConfiguration = tokenConfiguration;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            var user = _userRepository.ValidadeCredentials(userCredentials);

            if (user == null) return null;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateUpdateToken();

            user.RefreshToken = refreshToken;   
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_tokenConfiguration.DaysToExpire);

            var updateToken = UpdateToken(user, accessToken, refreshToken);

            return updateToken;
        }

        public TokenVO ValidateCredentials(TokenVO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GerPrincipalFromExpiredToken(accessToken);

            var username = principal.Identity.Name;

            var user = _userRepository.ValidateCredentials(username);

            if (user == null 
                || user.RefreshToken != refreshToken 
                || user.RefreshTokenExpiryTime <= DateTime.Now) return null;

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateUpdateToken();

            user.RefreshToken = refreshToken;

            var updateToken = UpdateToken(user, accessToken, refreshToken);

            return updateToken;
        }

        public bool RevokeToken(string userName)
        {
            return _userRepository.RevokeToken(userName);
        }

        private TokenVO UpdateToken(User user, string accessToken, string refreshToken)
        {
            _userRepository.UpdateUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_tokenConfiguration.Minutes);

            return new TokenVO(
                true,
                createDate.ToString(_DATE_FORMAT),
                expirationDate.ToString(_DATE_FORMAT),
                accessToken,
                refreshToken
            );
        }
    }
}
