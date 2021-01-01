using System;
using System.Collections.Generic;
using System.Linq;

using PVBot.DataObjects.Base;
using PVBot.DataObjects.Contracts.Services;
using PVBot.DataObjects.Models;

namespace PVBot.Application.Queries
{
    public class GetMessagesQuery : BaseQuery<Func<Message, bool>, List<Message>>
    {
        private readonly IChatbotService _twilioService;

        public GetMessagesQuery(IChatbotService twilioService)
        {
            _twilioService = twilioService;
        }

        public override List<Message> Execute(Func<Message, bool> query = null)
        {
            var messages = _twilioService.GetMessages();

            if (query != null)
                messages = messages.Where(query).ToList();

            return messages;
        }
    }
}
