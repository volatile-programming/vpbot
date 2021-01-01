using DryIoc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Commands;

using PVBot.Application.Commands;
using PVBot.Application.Repositories;
using PVBot.Clients.Portable.Extensions;
using PVBot.Clients.UI.Factories;
using PVBot.DataObjects.Contracts.Factories;
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
            container.Setup(m => m.Resolve(typeof(SaveStateCommand), It.IsAny<IfUnresolved>()))
                .Returns(() => new SaveStateCommand());

            _sut = new CommandFactory(container.Object);
        }

        [TestMethod]
        public void MakeCommand()
        {
            var command = _sut.MakeCommand<SaveStateCommand>();

            command.Should().NotBeNull();
            command.Should().BeAssignableTo<SaveStateCommand>();
        }

        [TestMethod]
        public void MakeDelegate()
        {
            var command = _sut.MakeDelegateCommand<SaveStateCommand>();

            command.Should().NotBeNull();
            command.Should().BeAssignableTo<DelegateCommand>();
        }

        [TestMethod]
        public void MakeDelegateWithParmeter()
        {
            var container = new Mock<IContainer>();
            var repository = new Mock<IRepositoryFactory>();

            repository.Setup(m => m.MakeRepository<MessagesRepository>())
                .Returns(() => null);

            container.Setup(m => m.Resolve(typeof(SendMessageCommand), It.IsAny<IfUnresolved>()))
                .Returns(() => new SendMessageCommand(repository.Object));

            var sut = new CommandFactory(container.Object);

            var command = sut.MakeDelegateWithParmeter<SendMessageCommand, Message>();

            command.Should().NotBeNull();
            command.Should().BeAssignableTo<DelegateCommand<Message>>();
        }
    }
}
