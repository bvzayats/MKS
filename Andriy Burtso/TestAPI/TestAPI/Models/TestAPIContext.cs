using Microsoft.EntityFrameworkCore;

namespace TestAPI.Models
{
    public class TestAPIContext: DbContext
    {
        public TestAPIContext(DbContextOptions<TestAPIContext> options) :base(options) { }
        
        public DbSet<User> Users { get; set;  }
        
    }
}
