using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
