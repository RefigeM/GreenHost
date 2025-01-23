using GreenHost.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GreenHost.Contexts
{
    public class GreenHostDbContext : IdentityDbContext
    {
        public GreenHostDbContext(DbContextOptions opt) : base(opt)
        {
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<AppUser> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GreenHostDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
