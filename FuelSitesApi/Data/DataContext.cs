using Microsoft.EntityFrameworkCore;

namespace FuelSitesApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<FuelSite> FuelSites { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
