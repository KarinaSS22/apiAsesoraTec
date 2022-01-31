using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class Calificacion
    {
        [Key]
        public int idCalificacion { get; set; }
        
        public char calificacion { get; set; }
    }
}
