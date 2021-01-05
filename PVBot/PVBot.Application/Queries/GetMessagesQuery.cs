using System;
using System.Collections.Generic;
using System.Linq;

using Ardalis.GuardClauses;

using PVBot.DataObjects.Base;
using PVBot.DataObjects.Contracts.Core;
using PVBot.DataObjects.Contracts.Services;
using PVBot.DataObjects.Models;

namespace PVBot.Application.Queries
{
    public class GetMessagesQuery : BaseQuery<Func<Message, bool>, List<Message>>
    {
        private readonly IChatbotService _chatbotService;
        private readonly IUnitOfWork _unitOfWork;

        public GetMessagesQuery(IChatbotService chatbotService, IUnitOfWork unitOfWork)
        {
            Guard.Against.Null(chatbotService, nameof(chatbotService));
            Guard.Against.Null(unitOfWork, nameof(unitOfWork));

            _chatbotService = chatbotService;
            _unitOfWork = unitOfWork;
        }

        public override List<Message> Execute(Func<Message, bool> query = null)
        {
            // TODO: add support for other types of messages
            //var textMessagePersistence = _unitOfWork.GetPersistence<Message>(typeof(Message));


            //if (_chatbotService.HasUnreadMessages())
            //{
            //    var unreadMessages = _chatbotService.GetMessages();

            //    foreach (var message in unreadMessages)
            //        textMessagePersistence.Add(message);

            //    _unitOfWork.CommitChanges();
            //}

            //var messages = textMessagePersistence.Query();
            var messages = _chatbotService.GetMessages();

            if (query != null)
                messages = messages.Where(query).ToList();

            return messages;
        }
    }
}
