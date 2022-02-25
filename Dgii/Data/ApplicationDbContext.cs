using Dgii.DataClasses;
using Microsoft.EntityFrameworkCore;

namespace Dgii.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Registro> Registros { get; set; }
    }
}
