using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BakeryApi.Models.Data
{
    public partial class BakeryContext : DbContext
    {
        public BakeryContext()
        {
        }

        public BakeryContext(DbContextOptions<BakeryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bread> Breads { get; set; }
        public virtual DbSet<DeliverTime> DeliverTimes { get; set; }
        public virtual DbSet<Factor> Factors { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new BreadConfig());
            modelBuilder.ApplyConfiguration(new DeliverTimeConfig());
            modelBuilder.ApplyConfiguration(new FactorConfig());
            modelBuilder.ApplyConfiguration(new UserAddressConfig());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
