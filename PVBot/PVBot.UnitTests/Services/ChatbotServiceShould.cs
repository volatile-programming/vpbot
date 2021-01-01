using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PVBot.Application.Mock.Services;
using PVBot.DataObjects.Models;

namespace PVBot.UnitTests.Services
{
    [TestClass]
    public class ChatbotServiceShould
    {
        private ChatbotService _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new ChatbotService();
        }

        [TestMethod]
        public void GetMessages()
        {
            var messages = _sut.GetMessages();

            messages.Should().NotBeEmpty();
            messages.Should().NotContainNulls();
            messages.Should().AllBeAssignableTo<Message>();
        }

        [TestMethod]
        public void ResiveMessage()
        {
            var message = _sut.ResiveMessage();

            message.Should().NotBeNull();
            message.Should().BeAssignableTo<Message>();
        }

        [TestMethod]
        public void SendMessage()
        {
            var message = _sut.ResiveMessage();

            _sut.SendMessage(message);
        }
    }
}
