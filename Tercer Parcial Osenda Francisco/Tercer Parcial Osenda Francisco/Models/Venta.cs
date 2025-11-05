using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercer_Parcial_Osenda_Francisco.Models
{
    public class Venta
    {
        public int ID { get; set; }
        public decimal Monto { get; set; }       


        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }
        public List<Producto> Productos { get; set; } = new List<Producto>();

    }
}
