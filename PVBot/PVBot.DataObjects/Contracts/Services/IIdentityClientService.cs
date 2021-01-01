using System.Threading.Tasks;
using PVBot.DataObjects.Models;

namespace PVBot.DataObjects.Contracts.Services
{
    public interface IIdentityClientService
    {
        Task<User> Authenticate(string accessToken);

        Task<Tokens> Reauthorize(string refreshToken);

        Task<(User, Tokens)> Login();

        Task LogOut();
    }
}
