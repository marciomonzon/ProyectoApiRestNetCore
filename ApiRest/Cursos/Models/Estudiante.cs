using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursos.Models
{
    public class Estudiante
    {
        public Estudiante()
        {
            Matricula = new HashSet<Matricula>();
        }

        [Key]
        public int IdEstudiante { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "El codigo es obligatorio")]
        [MinLength(10, ErrorMessage = "El codigo deve ser mínimo de 10 caracteres")]
        [MaxLength(10, ErrorMessage = "El codigo deve ser máximo de 10 caracteres")]
        public string Codigo { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MinLength(10, ErrorMessage = "El nombre deve ser mínimo de 3 caracteres")]
        [MaxLength(10, ErrorMessage = "El nombre deve ser máximo de 50 caracteres")]
        public string Nombre { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        [MinLength(10, ErrorMessage = "El apellido deve ser mínimo de 3 caracteres")]
        [MaxLength(10, ErrorMessage = "El apellido deve ser máximo de 50 caracteres")]
        public string Apellido { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string NombreApellido { get; set; }


        [Column(TypeName = "date")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime? FechaNacimiento { get; set; }

        public virtual ICollection<Matricula> Matricula { get; set; }
    }
}
