using PVBot.DataObjects.Contracts;

namespace PVBot.Application.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly IAuth0Service _auth0Service;

        public LoginCommand(IAuth0Service auth0Service)
        {
            _auth0Service = auth0Service;
        }

        public void Execute()
        {
            _auth0Service.Login();
        }
    }
}
