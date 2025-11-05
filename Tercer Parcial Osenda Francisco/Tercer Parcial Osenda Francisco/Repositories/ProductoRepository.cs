using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercer_Parcial_Osenda_Francisco.Data;
using Tercer_Parcial_Osenda_Francisco.Models;

namespace Tercer_Parcial_Osenda_Francisco.Repositories
{
    public static class ProductoRepository
    {
        public static void GuardarProducto(Producto producto)
        {
            using var context = new ApplicationDbContext();
            context.Productos.Add(producto);
            context.SaveChanges();
        }
        public static List<Producto> verProductos()
        {
            using var context = new ApplicationDbContext();
            return context.Productos.ToList();
        }

    }
}
