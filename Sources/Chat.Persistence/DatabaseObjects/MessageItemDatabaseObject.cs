using System;
using System.ComponentModel.DataAnnotations;

namespace Chat.Persistence.DatabaseObjects
{
    public class MessageItemDatabaseObject
    {
        public MessageItemDatabaseObject(Guid id, string user, string message, DateTime createdAt)
        {
            Id = id;
            User = user;
            Message = message;
            CreatedAt = createdAt;
        }

        [Key]
        public Guid Id { get; set; }

        public string User { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
