using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly_App.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<MembershipType> membershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rentals> Rentals { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}