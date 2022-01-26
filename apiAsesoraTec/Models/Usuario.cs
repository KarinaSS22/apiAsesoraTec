using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        public string nombre { get; set; }
        public string apellidoPat { get; set; }
        public string apellidoMat { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
        public string foto { get; set; }
        public int idSexo { get; set; }


    }
}
