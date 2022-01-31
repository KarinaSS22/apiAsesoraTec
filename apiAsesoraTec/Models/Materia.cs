using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class Materia
    {
        [Key]
        public int idMateria { get; set; }

        public string claveMat { get; set; }

        public int idNombreMat { get; set; }

        public int idCreditos { get; set; }
    }
}
