using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakeryApi.Models.Data
{
    public partial class Bread
    {
        public Bread()
        {
            Factors = new HashSet<Factor>();
        }

        public int Id { get; set; }
        public string BreadName { get; set; }
        public double PricePerUnit { get; set; }
        public int Unit { get; set; }
        public bool IsActive { get; set; } = true;
        public int MinCount { get; set; }
        public int MaxCount { get; set; }

        public ICollection<Factor> Factors { get; set; }
    }

    public class BreadConfig : IEntityTypeConfiguration<Bread>
    {
        public void Configure(EntityTypeBuilder<Bread> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.BreadName).IsRequired().HasColumnType("nvarchar(200)");
        }
    }
}
