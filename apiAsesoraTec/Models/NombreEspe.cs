using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class NombreEspe
    {

        [Key]
        public int idNombreEspe { get; set; }
        public string nombre { get; set; }
    }
}
