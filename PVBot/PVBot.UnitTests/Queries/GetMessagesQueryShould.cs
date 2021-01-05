using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PVBot.Application.Queries;
using PVBot.DataObjects.Contracts.Core;
using PVBot.DataObjects.Contracts.Services;
using PVBot.DataObjects.Models;

namespace PVBot.UnitTests.Queries
{
    [TestClass]
    public class GetMessagesQueryShould
    {
        private GetMessagesQuery _sut;
        private Mock<IChatbotService> _chatbotService;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IPersistence<Message>> _persistance;

        [TestInitialize]
        public void Inizialize()
        {
            var messages = new List<Message> { new TextMessage() };

            _chatbotService = new Mock<IChatbotService>();
            _chatbotService.Setup(m => m.HasUnreadMessages()).Returns(() => true);
            _chatbotService.Setup(m => m.GetMessages()).Returns(() => messages);

            _persistance = new Mock<IPersistence<Message>>();
            _persistance.Setup(m => m.Query(null)).Returns(() => messages);

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(m => m.GetPersistence<Message>(It.IsAny<Type>())).Returns(() => _persistance.Object);

            _sut = new GetMessagesQuery(_chatbotService.Object, _unitOfWork.Object);
        }

        [TestMethod]
        public void GuardsAgainstNullChatbotService()
        {
            Action action = () =>
                _ = new GetMessagesQuery(null, _unitOfWork.Object);

            action.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'chatbotService')");
        }

        [TestMethod]
        public void GuardsAgainstNullUnitOfWork()
        {
            Action action = () =>
                _ = new GetMessagesQuery(_chatbotService.Object, null);

            action.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'unitOfWork')");
        }

        [TestMethod]
        public void GetAllMessages()
        {
            var command = _sut.Execute();

            command.Should().NotBeEmpty();
            command.Should().AllBeAssignableTo<TextMessage>();
        }

        [TestMethod]
        public void GetAllTextMessages()
        {
            var command = _sut.Execute(x => x.Type == MessageTypes.Text);

            command.Should().NotBeEmpty();
            command.Should().AllBeAssignableTo<TextMessage>();
        }

        [TestMethod]
        public void GetPersistenceFromUnitOfWork()
        {
            var command = _sut.Execute();

            _unitOfWork.Verify(m => m.GetPersistence<Message>(It.IsAny<Type>()));
        }

        [TestMethod]
        public void CheckIfHasUnreadMessages()
        {
            var command = _sut.Execute();

            _chatbotService.Verify(m => m.HasUnreadMessages());
        }

        [TestMethod]
        public void GetMessagesFromChatbotService()
        {
            var command = _sut.Execute();

            _chatbotService.Verify(m => m.GetMessages());
        }

        [TestMethod]
        public void AddUnreadMessagesToPersistence()
        {
            var command = _sut.Execute();

            _persistance.Verify(m => m.Add(It.IsAny<Message>()));
        }

        [TestMethod]
        public void GetMessagesFromPersistence()
        {
            var command = _sut.Execute();

            _persistance.Verify(m => m.Query(null));
        }
    }
}
