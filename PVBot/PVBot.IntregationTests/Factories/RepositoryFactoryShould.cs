using DryIoc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using PVBot.Application.Mock.Services;
using PVBot.Application.Repositories;
using PVBot.Clients.UI.Factories;
using PVBot.DataObjects.Models;

namespace PVBot.IntregationTests.Factories
{
    [TestClass]
    public class RepositoryFactoryShould
    {
        private RepositoryFactory _sut;

        [TestInitialize]
        public void Inizialize()
        {
            var service = new ChatbotService();
            var presistence = new Persistence<Message>();
            var unitOfWork = new UnitOfWork<Message>(presistence);
            var repository = new MessagesRepository(service, unitOfWork);

            var container = new Mock<IContainer>();
            container.Setup(m => m.Resolve(typeof(MessagesRepository), It.IsAny<IfUnresolved>()))
                .Returns(() => repository);

            _sut = new RepositoryFactory(container.Object);
        }

        [TestMethod]
        public void MakeRepository()
        {
            var command = _sut.MakeRepository<MessagesRepository>();

            command.Should().NotBeNull();
            command.Should().BeAssignableTo<MessagesRepository>();
        }
    }
}
