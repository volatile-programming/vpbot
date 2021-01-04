using System;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using PVBot.DataObjects.Contracts.Core;
using PVBot.DataObjects.Contracts.Services;
using PVBot.DataObjects.Exceptions;
using PVBot.DataObjects.Models;

namespace PVBot.Application.Commands
{
    public class AuthoriseUserCommand : ICommand<IProcessAware>
    {
        private readonly IIdentityClientService _client;
        private readonly IApplicationConfig _applicationConfig;

        public AuthoriseUserCommand(IIdentityClientService client,
            IApplicationConfig applicationConfig)
        {
            _client = client;
            _applicationConfig = applicationConfig;
        }

        public async void Execute(IProcessAware model)
        {
            Guard.Against.Null(model, nameof(model));

            model.IsLoading = true;

            var errorMessage = await this.Authenticate(null, 1);

            model?.ErrorCallBack(errorMessage);
        }

        private async Task<string> Authenticate(Exception exception, int count)
        {
            try
            {
                Tokens tokens = _applicationConfig.Tokens;
                User userInfo = _applicationConfig.User;

                if (exception is null && !(tokens is null))
                {
                    var currentUserInfo = await _client.Authenticate(tokens.AccessToken);

                    if (!(userInfo.Equals(currentUserInfo)))
                        if (!(_applicationConfig.User.Equals(currentUserInfo)))
                            _applicationConfig.User = currentUserInfo;
                }
                else if (exception is AccessTokenException && !(tokens is null))
                {
                    tokens = await _client.Reauthorize(tokens.RefreshToken);
                    _applicationConfig.Tokens = tokens;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                if (count < 4)
                {
                    ex = (ex is AccessTokenException) ? ex : null;
                    return await this.Authenticate(ex, count + 1);
                }
                else
                {
                    return ex.Message;
                }
            }
        }
    }
}
