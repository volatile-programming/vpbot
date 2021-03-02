using Microsoft.VisualStudio.TestTools.UnitTesting;

using DryIoc;
using FluentAssertions;
using AutoMapper;
using Moq;
using Prism.Commands;
using Prism.Events;

using VPBot.Application.Commands;
using VPBot.Clients.Portable.Extensions;
using VPBot.Clients.UI.Factories;
using VPBot.DataObjects.Contracts.Core;
using VPBot.DataObjects.Contracts.Services;
using VPBot.DataObjects.Models;

namespace VPBot.IntregationTests.Factories
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
            var repository = new Mock<IRepository<Message>>();
            var eventAgregator = new Mock<IEventAggregator>();
            var chatbotService = new Mock<IChatbotService>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var mapper = new Mock<IMapper>();

            container.Setup(m => m.Resolve(typeof(SendMessageCommand), It.IsAny<IfUnresolved>()))
                .Returns(() => new SendMessageCommand(messageRepository: repository.Object,
                    eventAgregator: eventAgregator.Object,
                    chabotService: chatbotService.Object,
                    unitOfWork: unitOfWork.Object,
                    mapper: mapper.Object));

            var sut = new CommandFactory(container.Object);

            var command = sut.MakeDelegateWithParameter<SendMessageCommand, IChatBoxModel>();

            command.Should().NotBeNull();
            command.Should().BeAssignableTo<DelegateCommand<IChatBoxModel>>();
        }
    }
}
