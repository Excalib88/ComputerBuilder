using ComputerBuilder.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerBuilder.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<CompatibilityProperty> compatibilityProperties { get; set; }
        public DbSet<ComputerBuild> computerBuilds { get; set; }
        public DbSet<HardwareItem> hardwareItems { get; set; }
        public DbSet<HardwareType> hardwareTypes { get; set; }
        public DbSet<Manufacturer> manufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuildItem>()
                .HasKey(t => new { t.ComputerBuildId, t.HardwareItemId});

            modelBuilder.Entity<BuildItem>()
                .HasOne(bi => bi.HardwareItem)
                .WithMany(i => i.BuildItems)
                .HasForeignKey(bi => bi.HardwareItemId);

            modelBuilder.Entity<BuildItem>()
                .HasOne(bi => bi.ComputerBuild)
                .WithMany(c => c.BuildItems)
                .HasForeignKey(bi => bi.ComputerBuildId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ComputerBuilder;Username=postgres;Password=889988");
        }


    }
}
