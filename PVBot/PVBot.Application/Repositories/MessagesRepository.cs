using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using PVBot.DataObjects.Contracts.Core;
using PVBot.DataObjects.Contracts.Services;
using PVBot.DataObjects.Models;

namespace PVBot.Application.Repositories
{
    public class MessagesRepository : ObservableCollection<Message>, IRepository<Message>
    {
        public readonly IChatbotService _chatBotService;
        public readonly IUnitOfWork<Message> _unitOfWork;

        public MessagesRepository(IChatbotService chatbotService,
            IUnitOfWork<Message> unitOfWork)
        {
            Guard.Against.Null(chatbotService, nameof(chatbotService));
            Guard.Against.Null(unitOfWork, nameof(unitOfWork));

            _chatBotService = chatbotService;
            _unitOfWork = unitOfWork;

            Refresh();
        }

        #region Refresh

        public void Refresh()
        {
            var isOutdated = _chatBotService.HasUnreadMessages();

            List<Message> messages = isOutdated ?
                _chatBotService.GetMessages() :
                _unitOfWork.Persistence.GetAll();

            Clear();

            if (!messages.Any())
                return;

            AddRange(messages);
        }

        public async Task RefreshAsync()
        {
            var isOutdated = await _chatBotService.HasUnreadMessagesAsync();

            List<Message> messages = isOutdated ?
                await _chatBotService.GetMessagesAsync() :
                await _unitOfWork.Persistence.GetAllAsync();

            Clear();

            if (!messages.Any())
                return;

            await AddRangeAsync(messages);
        }

        #endregion

        #region Add

        public new void Add(Message message)
        {
            base.Add(message);

            _unitOfWork.Persistence.Add(message);

            _unitOfWork.CommitChanges();

            _chatBotService.SendMessage(message);
        }

        public Task AddAsync(Message message)
        {
            base.Add(message);

            var tasks = new List<Task>();

            tasks.Add(_unitOfWork.Persistence.AddAsync(message));

            tasks.Add(_unitOfWork.CommitChangesAsync());

            tasks.Add(_chatBotService.SendMessageAsync(message));

            return Task.WhenAll(tasks);
        }

        public void AddRange(IEnumerable<Message> messages)
        {
            foreach (var message in messages)
            {
                base.Add(message);

                _unitOfWork.Persistence.Add(message);
            }

            _unitOfWork.CommitChanges();
        }

        public Task AddRangeAsync(IEnumerable<Message> messages)
        {
            var tasks = new List<Task>();

            foreach (var message in messages)
            {
                base.Add(message);

                tasks.Add(_unitOfWork.Persistence.AddAsync(message));
            }

            tasks.Add(_unitOfWork.CommitChangesAsync());

            return Task.WhenAll(tasks);
        }

        #endregion

        #region Update

        public void Update(Message message)
        {
            _unitOfWork.Persistence.Update(message);

            _unitOfWork.CommitChanges();
        }

        public Task UpdateAsync(Message message)
        {
            var tasks = new List<Task>();

            tasks.Add(_unitOfWork.Persistence.UpdateAsync(message));

            tasks.Add(_unitOfWork.CommitChangesAsync());

            return Task.WhenAll(tasks);
        }

        #endregion

        #region Remove

        public new void Remove(Message message)
        {
            base.Remove(message);

            _unitOfWork.Persistence.Remove(message);

            _unitOfWork.CommitChanges();
        }

        public Task RemoveAsync(Message message)
        {
            base.Remove(message);

            var tasks = new List<Task>();

            tasks.Add(_unitOfWork.Persistence.RemoveAsync(message));

            tasks.Add(_unitOfWork.CommitChangesAsync());

            return Task.WhenAll(tasks);
        }

        public Task ClearAsync()
        {
            Clear();

            return Task.CompletedTask;
        }

        #endregion
    }
}
