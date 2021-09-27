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
                .HasData(new MessageItemDatabaseObject(Guid.NewGuid(), "User Server 1", "Hi", DateTime.Now),
                    new MessageItemDatabaseObject(Guid.NewGuid(), "User Server 2", "There", DateTime.Now - TimeSpan.FromDays(2)),
                    new MessageItemDatabaseObject(Guid.NewGuid(), "User Server 3", "Milord", DateTime.Now - TimeSpan.FromDays(3)));
        }

        public DbSet<MessageItemDatabaseObject> MessageItems { get; set; }
    }
}
