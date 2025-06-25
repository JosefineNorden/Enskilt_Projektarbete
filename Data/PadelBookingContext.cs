using Enskilt_Projektarbete.Models;
using Microsoft.EntityFrameworkCore;

namespace Enskilt_Projektarbete.Data
{
    public class PadelBookingContext : DbContext
    {
        public PadelBookingContext(DbContextOptions<PadelBookingContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Booking> Bookings => Set<Booking>();
    }
}
