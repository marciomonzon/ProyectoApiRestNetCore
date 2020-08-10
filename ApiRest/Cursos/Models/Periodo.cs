using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cursos.Models
{
    public class Periodo
    {
        public Periodo()
        {
            Matricula = new HashSet<Matricula>();
        }

        [Key]
        public int IdPeriodo { get; set; }
        public int? Anio { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Matricula> Matricula { get; set; }
    }
}
