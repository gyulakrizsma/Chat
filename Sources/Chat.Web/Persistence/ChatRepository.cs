using System.Collections.Generic;
using System.Threading.Tasks;
using Chat.Web.Application;
using Chat.Web.Domain.Models;

namespace Chat.Web.Persistence
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
