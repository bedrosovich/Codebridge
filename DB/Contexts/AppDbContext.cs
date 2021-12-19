using Codebridge.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Codebridge.DB.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Dog> Dogs { get; set; }
    }
}
