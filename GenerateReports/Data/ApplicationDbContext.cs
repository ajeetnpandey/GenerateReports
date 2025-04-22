using Microsoft.EntityFrameworkCore;
using GenerateReports.Models;

namespace GenerateReports.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        public DbSet<ReportData> ReportItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ReportData>(entity =>
            {
                entity.ToTable("ReportItems"); // Optional: set the table name explicitly
                entity.HasKey(r => r.Id); // Assuming 'Id' is the primary key of ReportData

                // Additional configurations can go here if needed, e.g.:
                // entity.Property(r => r.SomeProperty).IsRequired();
            });
        }
    }
}

