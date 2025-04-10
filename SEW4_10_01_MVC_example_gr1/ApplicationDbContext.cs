using Microsoft.EntityFrameworkCore;
using SEW4_10_01_MVC_example_gr1.Models;

namespace SEW4_10_01_MVC_example_gr1
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    }
}
