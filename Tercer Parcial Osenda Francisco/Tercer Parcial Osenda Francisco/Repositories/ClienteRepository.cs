using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercer_Parcial_Osenda_Francisco.Data;
using Tercer_Parcial_Osenda_Francisco.Models;

namespace Tercer_Parcial_Osenda_Francisco.Repositorys
{
    public static class ClienteRepository
    { 
        public static void GuardarCliente(Cliente cliente)
        {
            using var context = new ApplicationDbContext();
            context.Clientes.Add(cliente);
            context.SaveChanges();
        }
        public static List<Cliente> verClientes()
        {
            using var context = new ApplicationDbContext();
            return context.Clientes.ToList();
        }
        
    }
}
