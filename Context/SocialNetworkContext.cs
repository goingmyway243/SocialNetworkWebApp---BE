using Microsoft.EntityFrameworkCore;
using SocialNetworkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Context
{
    public class SocialNetworkContext : DbContext
    {
        public SocialNetworkContext(DbContextOptions<SocialNetworkContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendShipEntity>()
                .HasKey(table => new { table.UserId, table.FriendId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<ChatroomEntity> Chatrooms { get; set; }
        public DbSet<ContentEntity> Contents { get; set; }
        public DbSet<FriendShipEntity> Friendships { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<ReactEntity> Reacts { get; set; }
        public DbSet<ContentEntity> Comments { get; set; }
    }
}
