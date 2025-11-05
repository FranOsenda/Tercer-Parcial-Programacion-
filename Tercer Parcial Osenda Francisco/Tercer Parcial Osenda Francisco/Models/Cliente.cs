using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercer_Parcial_Osenda_Francisco.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

      
        public Cliente (string Nombre, string Apellido, int Dni)
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Dni = Dni;
        }
    }
}
