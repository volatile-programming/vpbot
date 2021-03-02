using Ardalis.GuardClauses;
using AutoMapper;
using Prism.Events;
using VPBot.Application.Events;
using VPBot.DataObjects.Contracts.Core;
using VPBot.DataObjects.Contracts.Services;
using VPBot.DataObjects.Models;

namespace VPBot.Application.Commands
{
    public class SendMessageCommand : ICommand<IChatBoxModel>
    {
        private readonly IRepository<Message> _messageRepository;
        private readonly IChatbotService _chabotService;
        private readonly MessageSended _messageSended;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SendMessageCommand(IRepository<Message> messageRepository,
            IEventAggregator eventAgregator,
            IChatbotService chabotService,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            Guard.Against.Null(messageRepository, nameof(messageRepository));
            Guard.Against.Null(eventAgregator, nameof(eventAgregator));
            Guard.Against.Null(chabotService, nameof(chabotService));
            Guard.Against.Null(unitOfWork, nameof(unitOfWork));
            Guard.Against.Null(mapper, nameof(mapper));

            _messageSended = eventAgregator.GetEvent<MessageSended>();
            _messageRepository = messageRepository;
            _chabotService = chabotService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Execute(IChatBoxModel messageModel)
        {
            Guard.Against.Null(messageModel, nameof(messageModel));

            var message = MapMessage(messageModel.Message);

            _chabotService.SendMessage(message);

            _messageRepository.Add(message);

            var persistance = _unitOfWork.GetPersistence<TextMessage>(message.GetType());
            if (message is TextMessage textMessage)
                persistance.Add(textMessage);

            _unitOfWork.CommitChanges();

            messageModel.Text = string.Empty;

            // !: This is a Mock implementation of twilio response
            // TODO: remove on real service
            _messageSended.Publish(messageModel.Message);
        }

        private Message MapMessage(IMessageModel message)
        {
            if (message.Type == MessageTypes.File)
                return _mapper.Map<FileMessage>(message);

            if (message.Type == MessageTypes.Voice)
                return _mapper.Map<VoiceMessage>(message);

            if (message.Type == MessageTypes.Image)
                return _mapper.Map<ImageMessage>(message);

            return _mapper.Map<TextMessage>(message);
        }
    }
}
