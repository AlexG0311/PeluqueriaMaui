using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Proyecto.Model
{
    public class Usuarios
    {
        
      

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("apellidos")]
        public string Apellido { get; set; }

        [JsonProperty("correo")]
        public string Correo { get; set; }

        [JsonProperty("contraseña")]
        public string Contraseña { get; set; }

        [JsonProperty("telefono")]
        public int Telefono { get; set; }
    }
}
