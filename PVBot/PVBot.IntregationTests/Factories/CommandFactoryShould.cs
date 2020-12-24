using DryIoc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Commands;
using PVBot.Application.Commands;
using PVBot.Application.Factories;
using PVBot.DataObjects.Models;

namespace PVBot.IntregationTests.Factories
{
    [TestClass]
    public class CommandFactoryShould
    {
        private CommandFactory _sut;

        [TestInitialize]
        public void Inizialize()
        {
            var container = new Mock<IContainer>();
            container.Setup(m => m.Resolve(typeof(LoginCommand), It.IsAny<IfUnresolved>()))
                .Returns(() => new LoginCommand(null));
            container.Setup(m => m.Resolve(typeof(SendMessageCommand), It.IsAny<IfUnresolved>()))
                .Returns(() => new SendMessageCommand(null));

            _sut = new CommandFactory(container.Object);
        }

        [TestMethod]
        public void MakeCommand()
        {
            var command = _sut.MakeCommand<LoginCommand, DelegateCommand>();

            command.Should().NotBeNull();
            command.Should().BeAssignableTo<DelegateCommand>();
        }

        [TestMethod]
        public void MakeCommandWithParmeter()
        {
            var command = _sut.MakeCommandWithParmeter<SendMessageCommand, Message>();

            command.Should().NotBeNull();
            command.Should().BeAssignableTo<DelegateCommand<Message>>();
        }
    }
}
