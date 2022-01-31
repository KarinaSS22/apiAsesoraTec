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
        public string puesto { get; set; }
        public int idUsuario { get; set; }
    }
}
