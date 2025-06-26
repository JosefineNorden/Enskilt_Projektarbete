using ClassLibruary.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Enskilt_Projektarbete.Data
{
    public class PadelBookingContext : DbContext
    {
        public PadelBookingContext(DbContextOptions<PadelBookingContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Booking> Bookings => Set<Booking>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Freja Romeborn",
                    Email = "FrejaFis@gmail.com"

                });

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 2,
                    Name = "Jakob Stenfelt",
                    Email = "PolisFis@gmail.com"
                });

            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    CustomerId = 1, // första kunden
                    CourtNumber = 1,
                    StartTime = new DateTime(2025, 6, 26, 10, 0, 0),
                    EndTime = new DateTime(2025, 6, 26, 11, 0, 0)
                });

            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 2,
                    CustomerId = 2,
                    CourtNumber = 2,
                    StartTime = new DateTime(2025, 6, 26, 14, 0, 0),
                    EndTime = new DateTime(2025, 6, 26, 15, 0, 0)
                });

        }
    }
}
