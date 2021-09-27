using System.Collections.Generic;
using System.Threading.Tasks;
using Chat.Application;
using Chat.Domain.Models;

namespace Chat.Persistence
{
    public class ChatRepository : IChatRepository
    {
        public Task<IReadOnlyCollection<MessageItem>> GetMessages()
        {
            var staticItems = StaticDataSource.GetMessages();

            return Task.FromResult(staticItems);
        }

        public Task<MessageItem> AddMessageItem(string user, string message)
        {
            var messageItem = StaticDataSource.AddMessageItem(user, message);

            return Task.FromResult(messageItem);
        }
    }
}
