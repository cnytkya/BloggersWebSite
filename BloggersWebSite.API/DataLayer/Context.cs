using Microsoft.EntityFrameworkCore;

namespace BloggersWebSite.API.DataLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;Database=BloggersWebSiteAPI;Trusted_Connection=True;TrustServerCertificate=True");          
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
