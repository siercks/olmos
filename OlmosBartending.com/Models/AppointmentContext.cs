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

    }
}
