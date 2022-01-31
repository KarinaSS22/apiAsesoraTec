using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class Semestre
    {
        [Key]
        public int idSemestre { get; set; }
        public string semestre { get; set; }
    }
}
