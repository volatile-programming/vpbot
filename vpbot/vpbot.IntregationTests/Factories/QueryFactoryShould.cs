using DryIoc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using VPBot.Application.Factories;
using VPBot.Application.Queries;
using VPBot.Application.Services;
using VPBot.DataObjects.Contracts.Core;
using VPBot.DataObjects.Contracts.Services;

namespace VPBot.IntregationTests.Factories
{
    [TestClass]
    public class QueryFactoryShould
    {
        private QueryFactory _sut;

        [TestInitialize]
        public void Inizialize()
        {
            var chatbotService = new Mock<IChatbotService>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var quey = new GetMessagesQuery(chatbotService.Object, unitOfWork.Object);

            var container = new Mock<IContainer>();
            container.Setup(m => m.Resolve(typeof(GetMessagesQuery), It.IsAny<IfUnresolved>()))
                .Returns(() => quey);

            _sut = new QueryFactory(container.Object);
        }

        [TestMethod]
        public void MakeQuery()
        {
            var command = _sut.MakeQuery<GetMessagesQuery>();

            command.Should().NotBeNull();
            command.Should().BeAssignableTo<GetMessagesQuery>();
        }
    }
}
