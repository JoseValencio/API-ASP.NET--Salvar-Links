using Microsoft.EntityFrameworkCore;

namespace WebLinks.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Links> Links { get; set; }
    }

 
}
