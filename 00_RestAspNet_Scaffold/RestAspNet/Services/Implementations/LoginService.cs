using RestAspNet.Configurations;
using RestAspNet.Data.Value_Object;
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
        private TokenConfiguration _tokenConfiguration;

        private IUserRepository _userRepository;
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

            var acessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateUpdateToken();

            user.RefreshToken = refreshToken;   
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_tokenConfiguration.DaysToExpire);  
            
            _userRepository.UpdateUserInfo(user);

            DateTime createDate = DateTime.Now;   
            DateTime expirationDate = createDate.AddMinutes(_tokenConfiguration.Minutes);

            return new TokenVO()
            {
                Authenticated = true,
                Created = createDate.ToString(_DATE_FORMAT),
                Expiration = expirationDate.ToString(_DATE_FORMAT),
                AcessToken = acessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
