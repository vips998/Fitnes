using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.EF
{
    public partial class FitnesModelContext : DbContext
    {
        public FitnesModelContext()
            : base("name=FitnesModelContext")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TimeTable> TimeTable { get; set; }
        public virtual DbSet<Training> Training { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(e => e.Payment)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Visit)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .HasMany(e => e.TimeTable)
                .WithRequired(e => e.ServiceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Training>()
                .HasMany(e => e.Visit)
                .WithRequired(e => e.Training)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FIO)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Passport)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Client)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TimeTable)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserType>()
                .HasMany(e => e.User)
                .WithRequired(e => e.UserType)
                .WillCascadeOnDelete(false);
        }
    }
}
