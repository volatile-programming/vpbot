using PVBot.DataObjects.Models;

namespace PVBot.DataObjects.Contracts
{
    public interface IAuth0Service
    {
        User Login();
    }
}
