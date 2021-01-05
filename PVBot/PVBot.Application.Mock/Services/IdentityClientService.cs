using System.Threading.Tasks;

using PVBot.DataObjects.Contracts.Services;
using PVBot.DataObjects.Models;
using PVBot.Application.Mock.Models;

namespace PVBot.Application.Mock.Services
{
    public class IdentityClientService : IIdentityClientService
    {
        public Task<User> Authenticate(string accessToken)
        {
            return Task.FromResult(MockObjects.User);
        }

        public Task<Tokens> Reauthorize(string refreshToken)
        {
            return Task.FromResult(MockObjects.Tokens);
        }

        public Task<(User, Tokens)> Login()
        {
            return Task.FromResult((MockObjects.User, MockObjects.Tokens));
        }

        public Task LogOut() => Task.CompletedTask;
    }
}