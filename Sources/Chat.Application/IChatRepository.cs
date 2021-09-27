using System.Collections.Generic;
using System.Threading.Tasks;
using Chat.Domain.Models;

namespace Chat.Application
{
    public interface IChatRepository
    {
        Task<IReadOnlyList<MessageItem>> GetMessagesAsync();
        
        Task<MessageItem> AddMessageItemAsync(string user, string message);
    }
}
