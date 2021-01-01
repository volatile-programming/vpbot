using System;
using System.Threading.Tasks;
using PVBot.DataObjects.Base;
using PVBot.DataObjects.Contracts.Core;
using PVBot.DataObjects.Contracts.Factories;
using PVBot.DataObjects.Contracts.Services;
using PVBot.DataObjects.Exceptions;
using PVBot.DataObjects.Models;

namespace PVBot.Application.Commands
{
    public class AuthenticateUserCommand : BaseCommand<AuthenticateUserCommand>
    {
        private readonly IIdentityClientService _client;
        private readonly IPersistence<User> _userRepository;
        private readonly IPersistence<Tokens> _tokensRepository;

        public AuthenticateUserCommand(IIdentityClientService client,
            IPersistenceFactory persistanceFactory)
        {
            _client = client;
            _userRepository = persistanceFactory.MakePersistence<User>();
            _tokensRepository = persistanceFactory.MakePersistence<Tokens>();
        }

        public override async void Execute(object callback)
        {
            var errorMessage = await this.Login(null, 1);

            if (callback is Action<string> action)
                action(errorMessage);
        }

        private async Task<string> Login(Exception exception, int count)
        {
            try
            {
                Tokens tokens = _tokensRepository.Find(x => true);
                User userInfo = _userRepository.Find(x => true);

                if (exception is null && !(tokens is null))
                {
                    var currentUserInfo = await _client.Authenticate(tokens.AccessToken);

                    if (!(userInfo.Equals(currentUserInfo)))
                        _userRepository.Update(userInfo);
                }
                else if (exception is AccessTokenException && !(tokens is null))
                {
                    tokens = await _client.Reauthorize(tokens.RefreshToken);
                    _tokensRepository.Update(tokens);
                }
                else
                {
                    (userInfo, tokens) = await _client.Login();

                    _userRepository.Add(userInfo);
                    _tokensRepository.Add(tokens);
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                if (count < 4)
                    return await this.Login(ex, count + 1);
                else
                    return ex.Message;
            }
        }
    }
}
