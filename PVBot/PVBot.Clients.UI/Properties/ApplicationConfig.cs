using Plugin.Settings;
using Plugin.Settings.Abstractions;
using PVBot.DataObjects.Contracts.Core;
using PVBot.DataObjects.Models;

namespace PVBot.Clients.UI.Properties
{
    public class ApplicationConfig : IApplicationConfig
    {
        private readonly ISettings _setting;

        public ApplicationConfig()
        {
            _setting = CrossSettings.Current;
        }

        public User User
        {
            get
            {
                var user = new User
                {
                    Email = UserEmail,
                    UserName = UserName,
                    ImagePath = UserImagePath
                };

                return user;
            }
            set
            {
                if (value is null)
                    return;

                UserEmail = value.Email;
                UserName = value.UserName;
                UserImagePath = value.ImagePath;
            }
        }

        public Tokens Tokens
        {
            get
            {
                var tokens = new Tokens
                {
                    AccessToken = UserAccessToken,
                    RefreshToken = UserRefreshToken
                };

                return tokens;
            }
            set
            {
                if (value is null)
                    return;

                UserAccessToken = value.AccessToken;
                UserRefreshToken = value.RefreshToken;
            }
        }

        public string UserEmail
        {
            get => _setting.GetValueOrDefault(nameof(User.Email), string.Empty);
            set => _setting.AddOrUpdateValue(nameof(User.Email), value);
        }

        public string UserName
        {
            get => _setting.GetValueOrDefault(nameof(User.UserName), string.Empty);
            set => _setting.AddOrUpdateValue(nameof(User.UserName), value);
        }

        public string UserImagePath
        {
            get => _setting.GetValueOrDefault(nameof(User.ImagePath), string.Empty);
            set => _setting.AddOrUpdateValue(nameof(User.ImagePath), value);
        }

        public string UserAccessToken
        {
            get => _setting.GetValueOrDefault(nameof(Tokens.AccessToken), string.Empty);
            set => _setting.AddOrUpdateValue(nameof(Tokens.AccessToken), value);
        }

        public string UserRefreshToken
        {
            get => _setting.GetValueOrDefault(nameof(Tokens.RefreshToken), string.Empty);
            set => _setting.AddOrUpdateValue(nameof(Tokens.RefreshToken), value);
        }

        public void ResetTokens()
        {
            Tokens = new Tokens();
        }

        public void ResetUserInfo()
        {
            User = new User();
        }
    }
}
