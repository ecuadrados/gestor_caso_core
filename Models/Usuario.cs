using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_gestion_core.Models
{
    public class Usuario
    {
        public int usuario_id { get; set; }
        public string usuario_nombre { get; set; }
        public string usuario_apellido { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string usuario_email { get; set; }
        public string usuario_celular { get; set; }
        public string usuario_imagen { get; set; }
        public int gaula_id { get; set; }
        public int estado_id { get; set; }
        public int rol_id { get; set; }
        public DateTime fecha_actualizacion { get; set; }
        public string usuario_identificacion { get; set; }
    }
}
