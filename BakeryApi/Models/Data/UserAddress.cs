using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakeryApi.Models.Data
{
    public partial class UserAddress
    {
        public UserAddress()
        {
            Factors = new HashSet<Factor>();
        }

        public long Id { get; set; }
        public string Address { get; set; }
        public long UserId { get; set; }

        public User User { get; set; }
        public ICollection<Factor> Factors { get; set; }
    }

    public class UserAddressConfig : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(o => o.User)
                .WithMany(m => m.UserAddress)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
