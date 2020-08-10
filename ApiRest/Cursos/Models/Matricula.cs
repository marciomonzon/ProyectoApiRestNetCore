﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursos.Models
{
    public class Matricula
    {
        public Matricula()
        {
            InscripcionCurso = new HashSet<InscripcionCurso>();
        }

        [Key]
        public int IdEstudiante { get; set; }

        [Key]
        public int IdPeriodo { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; }


        [ForeignKey("IdEstudiante")]
        public virtual Estudiante Estudiante { get; set; }


        [ForeignKey(nameof(IdPeriodo))]
        public virtual Periodo Periodo { get; set; }

        public virtual ICollection<InscripcionCurso> InscripcionCurso { get; set; }
    }
}
