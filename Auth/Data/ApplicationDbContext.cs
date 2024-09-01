using Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.Data
{
    public class ApplicationDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;Database=AuthDb_new;Trusted_Connection=True;TrustServerCertificate=True");
        }
        public DbSet<User> users { get; set; }
    }
}
