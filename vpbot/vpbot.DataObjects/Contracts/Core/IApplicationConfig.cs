using VPBot.DataObjects.Models;

namespace VPBot.DataObjects.Contracts.Core
{
    public interface IApplicationConfig
    {
        User User { get; set; }
        string UserEmail { get; set; }
        string UserName { get; set; }
        string UserImagePath { get; set; }
        Tokens Tokens { get; set; }
        string UserAccessToken { get; set; }
        string UserRefreshToken { get; set; }

        void ResetTokens();

        void ResetUserInfo();
    }
}
