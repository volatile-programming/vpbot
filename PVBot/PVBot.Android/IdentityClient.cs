using System.Threading.Tasks;
using Auth0.OidcClient;
using PVBot.DataObjects.Contracts;
using PVBot.DataObjects.Models;

namespace PVBot.Droid
{
    public class IdentityClient : IIdentityClient
    {
        private readonly Auth0Client _client;

        public IdentityClient(Auth0Client client)
        {
            _client = client;
        }

        public async Task<User> Login()
        {
            var loginResult = await _client.LoginAsync();

            return null;
        }

        public Task LogOut() => _client.LogoutAsync();
    }
}