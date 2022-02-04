using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class Carrera
    {
        [Key]
        public int idCarrera { get; set; }
        public string claveCarre { get; set; }
        public string nombre { get; set; }
        public string abreviatura { get; set; }
    }
}
