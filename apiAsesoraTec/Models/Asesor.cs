using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Models
{
    public class Asesor
    {
        [Key]
        public int idAsesor { get; set; }

        public int numReloj { get; set; }

        public string nombre { get; set; }

        public string apellidoPat { get; set; }

        public string apellidoMat { get; set; }

        public string informacion { get; set; }

        public int idTitulo { get; set; }

        public int idSexo { get; set; }

        public int idUsuario { get; set; }

    }
}
