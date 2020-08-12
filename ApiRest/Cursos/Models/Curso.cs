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
        [MaxLength(10, ErrorMessage = "El código debe ser máximo de 10 caracteres")]
        [MinLength(2, ErrorMessage = "El código debe ser mínimo de 2 caracteres")]
        public string Codigo { get; set; }

        [StringLength(100)]
        [MaxLength(100, ErrorMessage = "La descripcion debe ser máximo de 100 caracteres")]
        [MinLength(5, ErrorMessage = "La descripcion debe ser mínimo de 5 caracteres")]
        public string Descripcion { get; set; }

        public bool? Estado { get; set; }

        public virtual ICollection<InscripcionCurso> InscripcionCurso { get; set; }
    }
}
