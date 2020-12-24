using DryIoc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PVBot.Application.Factories;
using PVBot.Application.Queries;
using PVBot.Application.Services;

namespace PVBot.IntregationTests.Factories
{
    [TestClass]
    public class QueryFactoryShould
    {
        private QueryFactory _sut;

        [TestInitialize]
        public void Inizialize()
        {
            var service = new TwilioService();
            var quey = new GetMessagesQuery(service);

            var container = new Mock<IContainer>();
            container.Setup(m => m.Resolve(typeof(GetMessagesQuery), It.IsAny<IfUnresolved>()))
                .Returns(() => quey);

            _sut = new QueryFactory(container.Object);
        }

        [TestMethod]
        public void CreateQueryIntance()
        {
            var command = _sut.Make<GetMessagesQuery>();

            command.Should().NotBeNull();
            command.Should().BeAssignableTo<GetMessagesQuery>();
        }
    }
}
