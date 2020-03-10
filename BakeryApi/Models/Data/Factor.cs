using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakeryApi.Models.Data
{
    public partial class Factor
    {
        public long Id { get; set; }
        public int BreadId { get; set; }
        public int BreadCount { get; set; }
        public long UserAddressId { get; set; }
        public bool IsPaid { get; set; }
        public bool IsDelivered { get; set; }
        public bool IsFinished { get; set; }
        public int PaymentType { get; set; }
        public string TrackingCode { get; set; }
        public double TotalPrice { get; set; }
        public int DeliverTimeId { get; set; }

        public virtual Bread Bread { get; set; }
        public virtual DeliverTime DeliverTime { get; set; }
        public virtual UserAddress UserAddress { get; set; }
    }

    public class FactorConfig : IEntityTypeConfiguration<Factor>
    {
        public void Configure(EntityTypeBuilder<Factor> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.TrackingCode).IsRequired().HasColumnType("varchar(10)");

            builder.HasOne(o => o.Bread)
                .WithMany(m => m.Factors)
                .HasForeignKey(f => f.BreadId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.DeliverTime)
                .WithMany(m => m.Factors)
                .HasForeignKey(f => f.DeliverTimeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.UserAddress)
                .WithMany(m => m.Factors)
                .HasForeignKey(f => f.UserAddressId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
