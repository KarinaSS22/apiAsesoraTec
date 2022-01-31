using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class Departamento
    {
        [Key]
        public int idDepartamento { get; set; } 

        public string departamento { get; set; }
    }
}
