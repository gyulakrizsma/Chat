using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Application;
using Chat.Domain.Models;
using Chat.Persistence.DatabaseObjects;
using Microsoft.EntityFrameworkCore;

namespace Chat.Persistence
{
    public class ChatRepository : IChatRepository
    {
        private readonly ChatDbContext _db;

        public ChatRepository(ChatDbContext db)
        {
            _db = db;
        }

        public async Task<IReadOnlyList<MessageItem>> GetMessagesAsync()
        {
            var messageItems = await _db.MessageItems.OrderBy(m => m.CreatedAt).ToListAsync();

            return messageItems.Select(mi => new MessageItem(mi.User, mi.Message, mi.CreatedAt)).ToList();
        }

        public async Task<MessageItem> AddMessageItemAsync(string user, string message)
        {
            var messageItem = new MessageItemDatabaseObject(Guid.NewGuid(), user, message, DateTime.UtcNow);

            await _db.MessageItems.AddAsync(messageItem);
            await _db.SaveChangesAsync();

            return new MessageItem(messageItem.User, messageItem.Message, messageItem.CreatedAt);

        }
    }
}
