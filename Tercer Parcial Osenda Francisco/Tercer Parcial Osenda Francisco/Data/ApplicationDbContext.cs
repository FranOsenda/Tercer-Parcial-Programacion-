using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercer_Parcial_Osenda_Francisco.Models;   

namespace Tercer_Parcial_Osenda_Francisco.Data
{
    public class ApplicationDbContext : DbContext
    {
       public DbSet<Cliente> Clientes { get; set; } 
       public DbSet<Venta> Ventas { get; set; }
       public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=localhost;Database=TercerParcialOF;Trusted_Connection=True;TrustServerCertificate=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venta>()
                .HasMany(v => v.Productos)
                .WithMany();
        }
    }
}
