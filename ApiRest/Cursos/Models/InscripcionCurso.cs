﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursos.Models
{
    public class InscripcionCurso
    {
        [Key]
        public int IdEstudiante { get; set; }
        [Key]
        public int IdPeriodo { get; set; }
        [Key]
        public int IdCurso { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; }


        [ForeignKey("IdEstudiante,IdPeriodo")]
        public virtual Matricula Matricula { get; set; }


        [ForeignKey("IdCurso")]
        public virtual Curso Curso { get; set; }
    }
}
