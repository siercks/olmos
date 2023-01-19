using Microsoft.EntityFrameworkCore;
using OlmosBartending.com.Models;

namespace OlmosBartending.com.Models
{
    public class AppointmentContext:DbContext
    {
        //
        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options)
        {
            //
        }
        public DbSet<Appointment> AppointmentList { get; set; }
        //public DbSet<User> UserList { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Data seeding.
            //modelBuilder.Entity<User>().HasNoKey();
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { EventId = 1, CustomerName = "Andrew Siercks", CustomerEmail = "asiercks@gmail.com", DateRequested=DateTime.Today, ServiceRequested = ServiceRequested.Birthday, OptionalMessage = "" }
                //new Appointment { EventId = 2, CustomerName = "Andrew Siercks", CustomerEmail = "asiercks@gmail.com", ServiceRequested = "Quincy", OptionalMessage = "" },
                //new Appointment { EventId = 3, CustomerName = "Andrew Siercks", CustomerEmail = "asiercks@gmail.com", DateRequested=DateTime.Today, ServiceRequested = "Bar Mitzfah", OptionalMessage = "" }
                );
        }
    }
}
