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
        }

        public DbSet<FacturadorApi.Model.Cliente> Cliente{ get; set; } = default!;
    }
}
