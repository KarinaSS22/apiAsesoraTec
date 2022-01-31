using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class Creditos
    {
        [Key]
        public int idCreditos { get; set; }

        public string creditos { get; set; }
    }
}
