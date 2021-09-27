using System.Collections.Generic;
using System.Threading.Tasks;
using Chat.Domain.Models;

namespace Chat.Application
{
    public interface IChatRepository
    {
        Task<IReadOnlyCollection<MessageItem>> GetMessages();
        
        Task<MessageItem> AddMessageItem(string user, string message);
    }
}
