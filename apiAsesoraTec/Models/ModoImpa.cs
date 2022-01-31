using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class ModoImpa
    {
        [Key]
        public int idModoImpa { get; set; }

        public string modoImpa { get; set; }
    }
}
