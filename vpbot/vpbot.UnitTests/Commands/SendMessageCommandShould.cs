using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using FluentAssertions;

using VPBot.Application.Commands;
using VPBot.DataObjects.Contracts.Core;
using VPBot.DataObjects.Contracts.Services;
using VPBot.DataObjects.Models;
using AutoMapper;
using Prism.Events;
using VPBot.Application.Events;

namespace VPBot.UnitTests.Commands
{
    [TestClass]
    public class SendMessageCommandShould
    {
        private SendMessageCommand _sut;
        private Mock<IChatBoxModel> _messageModel;
        private Mock<IChatbotService> _chatbotService;
        private Mock<IRepository<Message>> _messageRepository;
        private Mock<IEventAggregator> _eventAgregator;
        private Mock<IPersistence<Message>> _persistance;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IMapper> _mapper;

        [TestInitialize]
        public void Inizialize()
        {
            _chatbotService = new Mock<IChatbotService>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _messageRepository = new Mock<IRepository<Message>>();
            _persistance = new Mock<IPersistence<Message>>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(m => m.GetPersistence<Message>(It.IsAny<Type>())).Returns(() => _persistance.Object);

            _eventAgregator = new Mock<IEventAggregator>();
            _eventAgregator.Setup(m => m.GetEvent<MessageSended>()).Returns(() => new MessageSended());

            var messageModel = new Mock<IMessageModel>();
            _messageModel = new Mock<IChatBoxModel>();
            _messageModel.SetupGet(m => m.Message).Returns(() => messageModel.Object);

            _mapper = new Mock<IMapper>();
            _mapper.Setup(m => m.Map<TextMessage>(It.IsAny<It.IsAnyType>()))
                .Returns(() => new TextMessage());

            _sut = new SendMessageCommand(messageRepository: _messageRepository.Object,
                eventAgregator: _eventAgregator.Object,
                chabotService: _chatbotService.Object,
                unitOfWork: _unitOfWork.Object,
                mapper: _mapper.Object);
        }

        [TestMethod]
        public void GuardsAgainstNullRepository()
        {
            Action action = () =>
                _ = new SendMessageCommand(messageRepository: null,
                    eventAgregator: _eventAgregator.Object,
                    chabotService: _chatbotService.Object,
                    unitOfWork: _unitOfWork.Object,
                    mapper: _mapper.Object);

            action.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'messageRepository')");
        }

        [TestMethod]
        public void GuardsAgainstNullEventAgregator()
        {
            Action action = () =>
                _ = new SendMessageCommand(messageRepository: _messageRepository.Object,
                    eventAgregator: null,
                    chabotService: _chatbotService.Object,
                    unitOfWork: _unitOfWork.Object,
                    mapper: _mapper.Object);

            action.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'eventAgregator')");
        }

        [TestMethod]
        public void GuardsAgainstNullChatbotService()
        {
            Action action = () =>
                _ = new SendMessageCommand(messageRepository: _messageRepository.Object,
                    eventAgregator: _eventAgregator.Object,
                    chabotService: null,
                    unitOfWork: _unitOfWork.Object,
                    mapper: _mapper.Object);

            action.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'chabotService')");
        }

        [TestMethod]
        public void GuardsAgainstNullUnitOfWork()
        {
            Action action = () =>
                _ = new SendMessageCommand(messageRepository: _messageRepository.Object,
                    eventAgregator: _eventAgregator.Object,
                    chabotService: _chatbotService.Object,
                    unitOfWork: null,
                    mapper: _mapper.Object);

            action.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'unitOfWork')");
        }

        [TestMethod]
        public void GuardsAgainstNullMapper()
        {
            Action action = () =>
                _ = new SendMessageCommand(messageRepository: _messageRepository.Object,
                    eventAgregator: _eventAgregator.Object,
                    chabotService: _chatbotService.Object,
                    unitOfWork: _unitOfWork.Object,
                    mapper: null);

            action.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'mapper')");
        }


        [TestMethod]
        public void GuardAgainstNullMessageModel()
        {
            Action action = () => _sut.Execute(null);

            action.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'messageModel')");
        }

        [TestMethod]
        public void SendMessageToChatbotService()
        {
            _sut.Execute(_messageModel.Object);

            _chatbotService.Verify(m => m.SendMessage(It.IsAny<Message>()));
        }

        [TestMethod]
        public void GetMessageFromModel()
        {
            _sut.Execute(_messageModel.Object);

            _messageModel.Verify(m => m.Message);
        }

        [TestMethod]
        public void GetMessageFromMapper()
        {
            _sut.Execute(_messageModel.Object);

            _mapper.Verify(m => m.Map<It.IsAnyType>(It.IsAny<It.IsAnyType>()));
        }

        [TestMethod]
        public void GetPersistenceFromUnitOfWork()
        {
            _sut.Execute(_messageModel.Object);

            _unitOfWork.Verify(m => m.GetPersistence<Message>(It.IsAny<Type>()));
        }

        [TestMethod]
        public void PersitsTheMessage()
        {
            _sut.Execute(_messageModel.Object);

            _persistance.Verify(m => m.Add(It.IsAny<Message>()));
        }

        [TestMethod]
        public void AddMessageInTheRepository()
        {
            _sut.Execute(_messageModel.Object);

            _messageRepository.Verify(m => m.Add(It.IsAny<Message>()));
        }

        [TestMethod]
        public void CommitAllChanges()
        {
            _sut.Execute(_messageModel.Object);

            _unitOfWork.Verify(m => m.CommitChanges(It.IsAny<Action<string>>()));
        }

        [TestMethod]
        public void GetMessageSendedEvent()
        {
            _sut.Execute(_messageModel.Object);

            _eventAgregator.Verify(m => m.GetEvent<MessageSended>());
        }
    }
}
