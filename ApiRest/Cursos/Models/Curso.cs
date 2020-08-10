using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cursos.Models
{
    public class Curso
    {
        public Curso()
        {
            InscripcionCurso = new HashSet<InscripcionCurso>();
        }

        [Key]
        public int IdCurso { get; set; }

        [StringLength(10)]
        public string Codigo { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        public bool? Estado { get; set; }

        public virtual ICollection<InscripcionCurso> InscripcionCurso { get; set; }
    }
}
