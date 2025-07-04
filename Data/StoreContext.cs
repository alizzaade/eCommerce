using eCommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data
{
    public class StoreContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
    }
}
