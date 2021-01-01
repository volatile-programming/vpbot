using System;
using Ardalis.GuardClauses;
using AutoMapper;

using PVBot.Application.Commands;
using PVBot.DataObjects.Contracts.Factories;
using PVBot.DataObjects.Models;
using PVBot.ViewModels;

namespace PVBot.Clients.UI.ViewModels
{
    public class MessageViewModel : ViewModelBase
    {
        private readonly IMapper _mapper;

        public MessageViewModel(IRepositoryFactory repositoryFactory, IMapper mapper)
        {
            Guard.Against.Null(repositoryFactory, nameof(repositoryFactory));
            Guard.Against.Null(mapper, nameof(mapper));

            _mapper = mapper;

            // TODO: implement user repository
            //UserRepository = repositoryFactory.Make<UserRepository>();
        }

        public Guid Id => Guid.NewGuid();
        public bool IsUser => true;

        // TODO: get data from user repository
        public string From => "@Me";

        // Can be expanded on the future.
        public string To => "Pvibot";
        public DateTime Date => DateTime.Now;
        public string Text { get; set; }
        public string AudioPath { get; set; }
        public string ImagePath { get; set; }
        public string AtachedFilePath { get; set; }
        public Message LastMessage { get; }
        public Message Message
        {
            get
            {
                Message message;

                if (Type == MessageTypes.File)
                    message = _mapper.Map<FileMessage>(this);
                else if (Type == MessageTypes.Voice)
                    message = _mapper.Map<VoiceMessage>(this);
                else if (Type == MessageTypes.Image)
                    message = _mapper.Map<ImageMessage>(this);
                else
                    message = _mapper.Map<TextMessage>(this);

                if (LastMessage?.IsUser == true)
                    UpdateLastMessageState();

                return message;
            }
        }

        public MessageTypes Type
        {
            get
            {
                if (!string.IsNullOrEmpty(AtachedFilePath))
                    return MessageTypes.File;

                if (!string.IsNullOrEmpty(AudioPath))
                    return MessageTypes.Voice;

                if (!string.IsNullOrEmpty(ImagePath))
                    return MessageTypes.Image;

                return MessageTypes.Text;
            }
        }

        public MessageStates State
        {
            get
            {
                if (LastMessage?.IsUser == false)
                    return MessageStates.UserOnly;

                return MessageStates.UserLast;
            }
        }

        private void UpdateLastMessageState()
        {
            if (LastMessage == null)
                return;

            var lastMessageState = LastMessage.State;

            if (lastMessageState == MessageStates.UserOnly)
                LastMessage.State = MessageStates.UserFirts;
            else if (lastMessageState == MessageStates.UserLast)
                LastMessage.State = MessageStates.UserMiddle;
        }
    }
}
