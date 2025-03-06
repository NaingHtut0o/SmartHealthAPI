using Microsoft.EntityFrameworkCore;
using SmartHealthAPI.Models;

namespace SmartHealthAPI.Data
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options) { }

        public DbSet<HealthCheckItemMaster> healthCheckItemMasters { get; set; }
        public DbSet<UrbanOsHealthCheck> urbanOsHealthChecks { get; set; }
        public DbSet<UrbanOsHealthCheckItems> urbanOsHealthCheckItems { get; set; }
        public DbSet<UrbanOsUsers> urbanOsUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HealthCheckItemMaster>().ToTable("health_check_item_master", schema: "public").HasKey(e =>  e.ItemId);
            modelBuilder.Entity<UrbanOsHealthCheck>().ToTable("urban_os_health_check", schema: "public").HasKey(e =>  e.Id);
            modelBuilder.Entity<UrbanOsHealthCheckItems>().ToTable("urban_os_health_check_items", schema: "public").HasKey(e =>  e.Id);
            modelBuilder.Entity<UrbanOsUsers>().ToTable("urban_os_users", schema: "public").HasNoKey();
        }
    }
}
