using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class Alumno
    {
        [Key]
        public int idAlumno { get; set; }

        public int numControl { get; set; }

        public int idUsuario { get; set; }

        public int idSemestre { get; set; }

        public int idCarrera { get; set; }

        public int idEspecialidad { get; set; }

    }
}
