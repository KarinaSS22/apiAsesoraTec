using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class Mat_Carre
    {
        [Key]
        public int idMatCarre { get; set; }

        public string claveInterna { get; set; }

        public int idMateria { get; set; }

        public int idCarrera { get; set; }
    }
}
