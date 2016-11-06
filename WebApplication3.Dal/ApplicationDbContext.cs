using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using RadaCode.Entities.Models.Identity;
using RadaCode.Entities.Models.UserIdea;

namespace RadaCode.Dal
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Vote> Votes { get; set; }
        public DbSet<UserIdea> Ideas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vote>()
                   .HasRequired(a => a.UserIdea)
                   .WithMany(g => g.Votes)
                   .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");

            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
        }
    }
}