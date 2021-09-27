using System.Collections.Generic;
using System.Threading.Tasks;
using Chat.Web.Domain.Models;

namespace Chat.Web.Application
{
    public interface IChatRepository
    {
        Task<IReadOnlyCollection<MessageItem>> GetMessages();
        
        Task<MessageItem> AddMessageItem(string user, string message);
    }
}
