using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductAPI.Models;

namespace ProductAPI.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }

    }
}
