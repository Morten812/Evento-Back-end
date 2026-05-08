using Evento_Back_end.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Evento_Back_end.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser, IdentityRole, string>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.EnableNotifications).HasDefaultValue(true);

            });

            builder.Entity<Services>()
                .Property(s => s.Price)
                .HasPrecision(18, 2);

            //builder.HasDefaultSchema("identity");

            builder.Entity<Request>()
              .Property(s => s.Status)
              .HasConversion<string>();

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}
