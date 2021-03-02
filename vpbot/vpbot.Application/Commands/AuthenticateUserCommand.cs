using System;
using System.Threading.Tasks;
using VPBot.DataObjects.Contracts.Core;
using VPBot.DataObjects.Contracts.Services;
using VPBot.DataObjects.Exceptions;
using VPBot.DataObjects.Models;

namespace VPBot.Application.Commands
{
    public class AuthenticateUserCommand : ICommand<Action<string>>
    {
        private readonly IIdentityClientService _client;
        private readonly IApplicationConfig _applicationConfig;

        public AuthenticateUserCommand(IIdentityClientService client,
            IApplicationConfig applicationConfig)
        {
            _client = client;
            _applicationConfig = applicationConfig;
        }

        public async void Execute(Action<string> callback)
        {
            var errorMessage = await this.Login(null, 1);

            callback(errorMessage);
        }

        private async Task<string> Login(Exception exception, int count)
        {
            try
            {
                if (!(exception is null))
                {
                    count += 1;
                }

                (User userInfo, Tokens tokens) = await _client.Login();
                _applicationConfig.User = userInfo;
                _applicationConfig.Tokens = tokens;

                return string.Empty;
            }
            catch (Exception ex)
            {
                if (count < 4)
                    return await this.Login(ex, count);
                else
                    return ex.Message;
            }
        }
    }
}
