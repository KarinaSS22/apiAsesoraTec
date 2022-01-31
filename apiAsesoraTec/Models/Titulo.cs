using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class Titulo
    {
        [Key]
        public int idTitulo { get; set; }
        public string titulo { get; set; }

    }
}
