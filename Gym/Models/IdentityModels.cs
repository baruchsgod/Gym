using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gym.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(9)]
        public string cedula { get; set; }

        [Required]
        [StringLength(50)]
        public string fName { get; set; }

        [Required]
        [StringLength(100)]
        public string lName { get; set; }

        [Required]
        [StringLength(12)]
        public string Telefono { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yy}")]
        public DateTime? BirthDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yy}")]
        public DateTime? BeginDate { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Membership> Memberships { get; set; }

        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<Calendar> Calendar { get; set; }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public DbSet<Payment> Payment { get; set; }

        public DbSet<Purchase> Purchase { get; set; }

        public DbSet<Activity> Activity { get; set; }

        public DbSet<Exercise> Exercise { get; set; }

        public DbSet<Reserve> Reserve { get; set; }

        public DbSet<Routine> Routine { get; set; }

        public DbSet<Metric> Metric { get; set; } 
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