using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace OlmosBartending.com.Models
{
    public class UserContext:IdentityDbContext<User>
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) 
        { 
            //
        }
        //public DbSet<User> UserList { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)       
        //{
        //    modelBuilder.Entity<User>().HasData(
        //            new User { CustomerId=1, UserName="asiercks", FirstName = "Andrew", LastName = "Siercks", Email="asiercks@gmail.com" },
        //            new User { CustomerId=2, UserName="arobbins", FirstName = "Andrew", LastName = "Robbins", Email="arob@gmail.com" }
        //        );
        //    //modelBuilder.Entity<User>().HasKey( x => x.CustomerId );
        //}
    }
}
