
using Microsoft.EntityFrameworkCore;
using IoTPlatform.Domain.Entities;

namespace IoTPlatform.Infrastructure.Data
{
    public class IoTPlatformDbContext : DbContext
    {
        //----------------------------------------constructor-----------------------
        public IoTPlatformDbContext(DbContextOptions<IoTPlatformDbContext> options)
            : base(options)
        {
        }

        //----------------------------------------database tables-----------------------
        public DbSet<DeviceAsset> Devices { get; set; }
        public DbSet<TelemetryMetric> TelemetryMetrics { get; set; }
        public DbSet<AlertRule> AlertRules { get; set; }
        public DbSet<MaintenanceLog> MaintenanceLogs { get; set; }

        //----------------------------------------database configuration-----------------------

        //----------------------------------------database configuration-----------------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //----------------------------------------device configuration-----------------------
            modelBuilder.Entity<DeviceAsset>(entity =>
            {
                // primary key
                entity.HasKey(d => d.Id);

                // unique serial number
                entity.HasIndex(d => d.SerialNumber).IsUnique();

                // required fields
                entity.Property(d => d.SerialNumber).IsRequired().HasMaxLength(20);
                entity.Property(d => d.Name).IsRequired().HasMaxLength(100);
                entity.Property(d => d.Status).IsRequired().HasMaxLength(20);

                // operating range value object
                entity.OwnsOne(d => d.Range, range =>
                {
                    range.Property(r => r.MinValue).HasColumnName("MinValue");
                    range.Property(r => r.MaxValue).HasColumnName("MaxValue");
                });

                entity.Navigation(d => d.Range).IsRequired();

                // serial number format
                entity.ToTable(t => t.HasCheckConstraint(
                    "CK_Device_Serial",
                    "[SerialNumber] LIKE 'DEV-[0-9][0-9][0-9][0-9][0-9]'"));

                // valid device statuses
                entity.ToTable(t => t.HasCheckConstraint(
                    "CK_Device_Status",
                    "[Status] IN ('Inactive', 'Active', 'Maintenance')"));

                // positive operating range
                entity.ToTable(t => t.HasCheckConstraint(
                    "CK_Device_Range",
                    "[MinValue] > 0 AND [MaxValue] > [MinValue]"));
            });

            //----------------------------------------telemetry configuration-----------------------
            modelBuilder.Entity<TelemetryMetric>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.MetricName).IsRequired().HasMaxLength(100);
                entity.Property(t => t.Unit).IsRequired().HasMaxLength(30);

                entity.HasIndex(t => t.DeviceId);

                entity.HasOne<DeviceAsset>()
                    .WithMany()
                    .HasForeignKey(t => t.DeviceId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            //----------------------------------------alert configuration-----------------------
            modelBuilder.Entity<AlertRule>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.MetricName).IsRequired().HasMaxLength(100);

                entity.HasIndex(a => a.DeviceId);

                entity.ToTable(t => t.HasCheckConstraint(
                    "CK_Alert_Range",
                    "[MinValue] > 0 AND [MaxValue] > [MinValue]"));

                entity.HasOne<DeviceAsset>()
                    .WithMany()
                    .HasForeignKey(a => a.DeviceId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            //----------------------------------------maintenance configuration-----------------------
            modelBuilder.Entity<MaintenanceLog>(entity =>
            {
                entity.HasKey(m => m.Id);

                entity.Property(m => m.Description).IsRequired().HasMaxLength(500);
                entity.Property(m => m.Technician).IsRequired().HasMaxLength(100);

                entity.HasIndex(m => m.DeviceId);

                entity.HasOne<DeviceAsset>()
                    .WithMany()
                    .HasForeignKey(m => m.DeviceId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

    }
}

