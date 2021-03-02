using System;
using Ardalis.GuardClauses;
using AutoMapper;
using Prism.Events;
using VPBot.Application.Events;
using VPBot.DataObjects.Contracts.Core;
using VPBot.DataObjects.Models;

namespace VPBot.Clients.UI.ViewModels
{
    public class ChatBoxViewModel : MessageViewModel, IChatBoxModel
    {
        private readonly IMapper _mapper;

        public ChatBoxViewModel(IApplicationConfig applicationConfig, IMapper mapper)
        {
            Guard.Against.Null(applicationConfig, nameof(applicationConfig));
            Guard.Against.Null(mapper, nameof(mapper));

            _mapper = mapper;

            IsUser = true;
            Id = Guid.NewGuid();
            UserImage = "pv_icon";
            From = applicationConfig.UserName;
            // Can be expanded on the future.
            To = "Pvibot";
            Text = string.Empty;
            AudioPath = string.Empty;
            ImagePath = string.Empty;
            AudioPath = string.Empty;
            AtachedFilePath = string.Empty;
        }

        public new DateTime Date => DateTime.Now;
        public IMessageModel LastMessage { get; private set; }
        public IMessageModel Message
        {
            get
            {
                var message = _mapper.Map<MessageViewModel>(this); ;

                if (LastMessage?.IsUser == true)
                    UpdateLastMessageState();

                LastMessage = message;

                return message;
            }
        }

        public new MessageTypes Type
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

        public new MessageStates State
        {
            get
            {
                if (LastMessage?.IsUser != false)
                    return MessageStates.UserOnlyState;

                return MessageStates.UserLastState;
            }
        }

        private void UpdateLastMessageState()
        {
            if (LastMessage == null)
                return;

            var lastMessageState = LastMessage.State;

            if (lastMessageState == MessageStates.UserOnlyState)
                LastMessage.State = MessageStates.UserFirtsState;
            else if (lastMessageState == MessageStates.UserLastState)
                LastMessage.State = MessageStates.UserMiddleState;
        }
    }
}
