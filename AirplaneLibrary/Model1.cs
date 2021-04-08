using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AirplaneLibrary
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=AirplaneModel")
        {
        }

        public virtual DbSet<Fare> Fares { get; set; }
        public virtual DbSet<Flight_Details> Flight_Details { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fare>()
                .Property(e => e.Amount)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Fare>()
                .Property(e => e.Final_Amount)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Fare>()
                .Property(e => e.Tax)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Flight_Details>()
                .Property(e => e.Arrival_Airport)
                .IsUnicode(false);

            modelBuilder.Entity<Flight_Details>()
                .Property(e => e.Depart_Airport)
                .IsUnicode(false);

            modelBuilder.Entity<Flight_Details>()
                .HasOptional(e => e.Fare)
                .WithRequired(e => e.Flight_Details)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Flight_Details>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Flight_Details)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Passenger>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.Passenger)
                .HasForeignKey(e => e.User_Email)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Passenger>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Passenger)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Mode)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Seat>()
                .Property(e => e.Available)
                .IsUnicode(false);

            modelBuilder.Entity<Seat>()
                .Property(e => e.Seat_Class)
                .IsUnicode(false);
        }
    }
}
