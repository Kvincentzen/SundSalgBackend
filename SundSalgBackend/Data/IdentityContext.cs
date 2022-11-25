using Microsoft.EntityFrameworkCore;
using SundSalgBackend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SundSalgBackend.Models.Configuration;

namespace SundSalgBackend.Data
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public IdentityContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CounselorConfiguration());
        }
        public DbSet<Counselor>? Counselors { get; set; }
        public DbSet<Product>? Products { get; set; }
    }
}

