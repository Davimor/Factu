using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Data
{
    public class FactuContext : DbContext
    {
        public FactuContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Factura> Facturas { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>().ToTable(nameof(Factura));
            modelBuilder.Entity<User>().ToTable(nameof(User));
        }
    }
}
