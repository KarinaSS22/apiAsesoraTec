using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class Ase_Carre
    {
        [Key]
        public int idAseCarre { get; set; }

        public int idAsesor { get; set; }

        public int idCarrera { get; set; }

    }
}
