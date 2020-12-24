using System.Threading.Tasks;
using PVBot.DataObjects.Models;

namespace PVBot.DataObjects.Contracts
{
    public interface IIdentityClient
    {
        Task<User> Login();
        Task LogOut();
    }
}
