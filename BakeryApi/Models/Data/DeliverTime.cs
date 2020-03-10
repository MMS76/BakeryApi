using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakeryApi.Models.Data
{
    public class DeliverTime
    {
        public DeliverTime()
        {
            Factors = new HashSet<Factor>();
        }

        public int Id { get; set; }
        public int FromHour { get; set; }
        public int ToHour { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Factor> Factors { get; set; }
    }

    public class DeliverTimeConfig : IEntityTypeConfiguration<DeliverTime>
    {
        public void Configure(EntityTypeBuilder<DeliverTime> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}