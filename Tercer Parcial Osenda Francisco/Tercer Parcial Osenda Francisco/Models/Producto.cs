using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercer_Parcial_Osenda_Francisco.Models
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public int? VentaID { get; set; } = null;   
    }
}