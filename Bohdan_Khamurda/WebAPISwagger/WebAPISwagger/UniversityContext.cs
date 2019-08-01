using Microsoft.EntityFrameworkCore;
using WebAPISwagger.Models;

namespace WebAPISwagger {
    public partial class UniversityContext : DbContext {
        public UniversityContext( DbContextOptions<UniversityContext> options )
            : base(options) {

            Database.EnsureCreated();
        }

        public virtual DbSet<Student> Students { get; set; }

        //protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder ) {

        //    if ( !optionsBuilder.IsConfigured ) {

        //        optionsBuilder.UseSqlServer( "Server=(localdb)\\mssqllocaldb;Database=University;Trusted_Connection=True;" );
        //    }
        //}
    }
}
