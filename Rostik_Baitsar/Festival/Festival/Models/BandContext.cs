using Microsoft.EntityFrameworkCore;

namespace Festival.Models
{
    public class BandContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }

        public BandContext(DbContextOptions<BandContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
