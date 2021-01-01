using System.Threading.Tasks;
using Auth0.OidcClient;
using PVBot.DataObjects.Contracts.Services;
using PVBot.DataObjects.Models;

namespace PVBot.iOS.Services
{
    public class IdentityClientService : IIdentityClientService
    {
        private readonly Auth0Client _client;

        public IdentityClientService(Auth0Client client)
        {
            _client = client;
        }

        public async Task<User> Authenticate()
        {
            var loginResult = await _client.LoginAsync();
            return null;
        }

        public Task LogOut() => _client.LogoutAsync();
    }
}