using Microsoft.EntityFrameworkCore;
using WebAPI_Server.Domain;

namespace WebAPI_Server.DA
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext() : base() => Database.EnsureCreated();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-IOU1NN3;Database=test;Trusted_connection=True");
        }
    }
}
