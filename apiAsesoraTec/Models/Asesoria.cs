using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class Asesoria
    {
        [Key]
        public int idAsesoria { get; set; }

        public DateTime fechaImpa { get; set; }

        public DateTime fechaSoli { get; set; }

        public string lugar { get; set; }

        public string comentario { get; set; }

        public DateTime horaInicio { get; set; }

        public DateTime horaFin { get; set; }

        public string tema { get; set; }

        public int idAlumno { get; set; }

        public int idAsesor { get; set; }

        public int idCalificacion { get; set; }

        public int idModoImpa { get; set; }

        public int idMateria { get; set; }
    }
}
