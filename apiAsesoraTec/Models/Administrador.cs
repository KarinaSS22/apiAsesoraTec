using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class Administrador
    {
        [Key]
        public int idAdministrador { get; set; }

        public int numEmpleado { get; set; }

        public string nombre { get; set; }

        public string apellidoPat { get; set; }

        public string apellidoMat { get; set; }

        public string puesto { get; set; }

        public int idSexo { get; set; }

        public int idUsuario { get; set; }
    }
}
