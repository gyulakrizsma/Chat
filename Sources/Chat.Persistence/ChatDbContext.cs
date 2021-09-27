using System;
using Chat.Persistence.DatabaseObjects;
using Microsoft.EntityFrameworkCore;

namespace Chat.Persistence
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<MessageItemDatabaseObject>().HasKey(i => i.Id);

            modelBuilder
                .Entity<MessageItemDatabaseObject>()
                .HasData(new MessageItemDatabaseObject(Guid.NewGuid(), "Joffrey", "Brilliant", DateTime.UtcNow - TimeSpan.FromDays(1)),
                    new MessageItemDatabaseObject(Guid.NewGuid(), "Ninja", "Great resource, thanks", DateTime.UtcNow - TimeSpan.FromDays(2)),
                    new MessageItemDatabaseObject(Guid.NewGuid(), "Patricia", "Sounds good to me", DateTime.UtcNow - TimeSpan.FromDays(3)));
        }

        public DbSet<MessageItemDatabaseObject> MessageItems { get; set; }
    }
}
