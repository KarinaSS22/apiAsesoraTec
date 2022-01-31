using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class Especialidad
    {
        [Key]
        public int idEspecialidad { get; set; }
        public string claveEspe { get; set; }
        public int idNombreEspe { get; set; }
        public int idCarrera { get; set; }
    }
}
