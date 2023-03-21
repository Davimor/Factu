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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>().ToTable(nameof(Factura));
        }
    }
}
