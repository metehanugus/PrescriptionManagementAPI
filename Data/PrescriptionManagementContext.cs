using Microsoft.EntityFrameworkCore;
using PrescriptionManagementAPI.Models;

namespace PrescriptionManagementAPI.Data
{
    public class PrescriptionManagementContext : DbContext
    {
        public PrescriptionManagementContext(DbContextOptions<PrescriptionManagementContext> options)
            : base(options)
        {
        }

        // Existing DbSet properties
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionDetail> PrescriptionDetails { get; set; }
        public DbSet<PaymentReport> PaymentReports { get; set; }

        // Added DbSet for Users
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Existing entity-to-table mappings
            modelBuilder.Entity<Medicine>()
                 .Property(m => m.Price)
                 .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<PaymentReport>()
                .Property(p => p.TotalAmountDue)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Prescription>()
                .Property(p => p.TotalPrice)
                .HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Medicine>().ToTable("Medicine");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Pharmacy>().ToTable("Pharmacy");
            modelBuilder.Entity<Prescription>().ToTable("Prescription");
            modelBuilder.Entity<PrescriptionDetail>().ToTable("PrescriptionDetail");
            modelBuilder.Entity<PaymentReport>().ToTable("PaymentReport");

            // Mapping for User entity
            modelBuilder.Entity<User>().ToTable("User");

           
        }
    }
}
