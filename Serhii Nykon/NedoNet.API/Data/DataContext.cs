using Microsoft.EntityFrameworkCore;
using NedoNet.API.Data.Models;

namespace NedoNet.API.Data {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        }

        public DbSet<User> Users { get; set; }
    }
}