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
            context.Ventas.Add(venta);
            context.SaveChanges();
        }
        public static List<Venta> verVentas()
        {
            using var context = new ApplicationDbContext();
            return context.Ventas.ToList();
        }
        public static List<Venta> verVentasPorCliente(int dniCliente)
        {
            using var context = new ApplicationDbContext();
            return context.Ventas.Where(v => v.ClienteID == dniCliente).ToList();
        }

    }
}
