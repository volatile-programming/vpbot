using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Auth0.OidcClient;
using PVBot.DataObjects.Contracts.Services;
using PVBot.DataObjects.Exceptions;
using PVBot.DataObjects.Models;

namespace PVBot.Application.Services
{
    public class IdentityClientService : IIdentityClientService
    {
        private readonly IAuth0Client _client;

        public IdentityClientService(IAuth0Client client)
        {
            _client = client;
        }

        public async Task<User> Authenticate(string accessToken)
        {
            var userInfoResult = await _client.GetUserInfoAsync(accessToken);
            if (userInfoResult.IsError)
            {
                throw new AccessTokenException();
            }

            return GetUserInfo(userInfoResult.Claims);
        }

        public async Task<Tokens> Reauthorize(string refreshToken)
        {
            var tokensResult = await _client.RefreshTokenAsync(refreshToken);
            if (tokensResult.IsError)
            {
                throw new RefreshTokenException();
            }

            return new Tokens
            {
                AccessToken = tokensResult.AccessToken,
                RefreshToken = tokensResult.RefreshToken
            };
        }

        public async Task<(User, Tokens)> Login()
        {
            var loginResult = await _client.LoginAsync();
            if (loginResult.IsError)
            {
                throw new LoginException();
            }

            var userInfo = GetUserInfo(loginResult.User.Claims);
            return (userInfo, new Tokens
            {
                AccessToken = loginResult.AccessToken,
                RefreshToken = loginResult.RefreshToken
            });
        }

        public Task LogOut() => _client.LogoutAsync();

        private User GetUserInfo(IEnumerable<Claim> userClaims)
        {
            return new User
            {
                Email = userClaims.FirstOrDefault(c => c.Type == "email")?.Value,
                UserName = userClaims.FirstOrDefault(c => c.Type == "nickname")?.Value,
                ImagePath = userClaims.FirstOrDefault(c => c.Type == "picture")?.Value
            };
        }
    }
}