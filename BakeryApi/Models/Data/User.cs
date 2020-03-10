using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakeryApi.Models.Data
{
    public sealed partial class User
    {
        public User()
        {
            UserAddress = new HashSet<UserAddress>();
        }

        public long Id { get; set; }
        public string FullName { get; set; }
        public string TelegramUserName { get; set; }
        public string TelegramName { get; set; }
        public long? TelegramChatId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int RoleEnum { get; set; }
        public string SecurityCode { get; set; }
        public DateTime? SecurityCodeExpiration { get; set; }

        public ICollection<UserAddress> UserAddress { get; set; }
    }

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.FullName).IsRequired(false).HasColumnType("nvarchar(200)");

            builder.Property(p => p.PhoneNumber).IsRequired().HasColumnType("varchar(11)");

            builder.Property(p => p.Email).IsRequired(false).HasColumnType("varchar(200)");

            builder.Property(p => p.SecurityCode).IsRequired(false).HasColumnType("varchar(6)");

            builder.Property(p => p.TelegramName).IsRequired(false).HasColumnType("nvarchar(200)");
            builder.Property(p => p.TelegramUserName).IsRequired(false).HasColumnType("varchar(100)");
        }
    }
}
