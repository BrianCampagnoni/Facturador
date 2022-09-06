using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FacturadorApi.Model;

namespace FacturadorApi.Data
{
    public class FacturadorDBContext : DbContext
    {
        public FacturadorDBContext (DbContextOptions<FacturadorDBContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasKey(c => new { c.Cli_ID});

            modelBuilder.Entity<Articulo>()
                .HasKey(a => new { a.Art_id });

            modelBuilder.Entity<Factura_Cabecera>()
                .HasKey(fc => new { fc.FC_ID });

            modelBuilder.Entity<Factura_Detalle>()
                .HasKey(fc => new { fc.FC_DTL_ID });

        }

        public DbSet<Cliente> Cliente{ get; set; } = default!;
        public DbSet<Articulo> Articulo { get; set; } = default!;
        public DbSet<Factura_Cabecera> Factura_Cabecera { get; set; } = default!;
        public DbSet<Factura_Detalle> Factura_Detalle { get; set; } = default!;

    }
}
