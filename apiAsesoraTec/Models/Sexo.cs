using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class Sexo
    {
        [Key]
        public int idSexo { get; set; }

        public char sexo { get; set; }
    }
}
