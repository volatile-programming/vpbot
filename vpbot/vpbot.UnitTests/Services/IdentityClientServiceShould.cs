using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VPBot.Application.Mock.Services;
using VPBot.DataObjects.Models;

namespace VPBot.UnitTests.Services
{
    [TestClass]
    public class IdentityClientServiceShould
    {
        private IdentityClientService _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new IdentityClientService();
        }

        [TestMethod]
        public async Task GetUserInfo()
        {
            User userInfo = await _sut.Authenticate("This is an access_token");

            userInfo.Should().NotBeNull();
            userInfo.Should().BeAssignableTo<User>();
        }

        [TestMethod]
        public async Task GetAuth0Credentials()
        {
            Tokens tokens = await _sut.Reauthorize("This is a refresh_token");

            tokens.Should().NotBeNull();
            tokens.Should().BeAssignableTo<Tokens>();
        }

        [TestMethod]
        public async Task GetUserInfoAndAuth0Credentials()
        {
            (User userInfo, Tokens tokens) = await _sut.Login();

            userInfo.Should().NotBeNull();
            userInfo.Should().BeAssignableTo<User>();
            tokens.Should().NotBeNull();
            tokens.Should().BeAssignableTo<Tokens>();
        }
    }
}
