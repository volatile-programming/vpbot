using System.Threading.Tasks;

using VPBot.DataObjects.Contracts.Services;
using VPBot.DataObjects.Models;
using VPBot.Application.Mock.Models;

namespace VPBot.Application.Mock.Services
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