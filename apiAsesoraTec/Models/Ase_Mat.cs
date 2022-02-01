using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class Ase_Mat
    {
        [Key]
        public int idAseMat { get; set; }

        public int idAsesor { get; set; }

        public int idMateria { get; set; }

        public int idDepartamento { get; set; }
    }
}
