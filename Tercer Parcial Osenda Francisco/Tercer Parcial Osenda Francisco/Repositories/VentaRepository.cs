using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercer_Parcial_Osenda_Francisco.Data;
using Tercer_Parcial_Osenda_Francisco.Models;

namespace Tercer_Parcial_Osenda_Francisco.Repositories
{
    public static class VentaRepository
    {
        public static void GuardarVenta(Venta venta)
        {
            using var context = new ApplicationDbContext();
            if (venta.Cliente != null)
            {
                context.Entry(venta.Cliente).State = EntityState.Unchanged;
            }
            else
            {
                var clienteExistente = context.Clientes.Find(venta.ClienteID);
                if (clienteExistente != null)
                    venta.Cliente = clienteExistente;
            }

            var productosAdjuntos = new List<Producto>();
            foreach (var producto in venta.Productos)
            {
                var productoExistente = context.Productos.Find(producto.ID);
                if (productoExistente != null)
                {                    
                    productoExistente.Stock = producto.Stock;
                    productosAdjuntos.Add(productoExistente);
                }
            }
            venta.Productos = productosAdjuntos;
            context.Ventas.Add(venta);
            context.SaveChanges();
        }
        public static List<Venta> verVentas()
        {
            using var context = new ApplicationDbContext();
            return context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Productos)
                .ToList();
        }
        public static List<Venta> verVentasPorCliente(int dniCliente)
        {
            using var context = new ApplicationDbContext();
            return context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Productos)
                .Where(v => v.Cliente.Dni == dniCliente)
                .ToList();
        }

    }
}
