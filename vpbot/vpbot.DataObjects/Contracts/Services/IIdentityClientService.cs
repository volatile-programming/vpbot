using System.Threading.Tasks;
using VPBot.DataObjects.Models;

namespace VPBot.DataObjects.Contracts.Services
{
    public interface IIdentityClientService
    {
        Task<User> Authenticate(string accessToken);

        Task<Tokens> Reauthorize(string refreshToken);

        Task<(User, Tokens)> Login();

        Task LogOut();
    }
}
