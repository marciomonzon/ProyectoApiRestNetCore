using Microsoft.EntityFrameworkCore;

namespace Cursos.Models
{
    public partial class CursosCTX : DbContext
    {
        public CursosCTX()
        {
        }

        public CursosCTX(DbContextOptions<CursosCTX> options)
            : base(options)
        {
        }

        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<InscripcionCurso> InscripcionCurso { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Periodo> Periodo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso);
                   

                entity.Property(e => e.IdCurso).ValueGeneratedNever();

                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante);
                   

                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.NombreApellido)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(concat([Nombre],' ',[Apellido]))");
            });

            modelBuilder.Entity<InscripcionCurso>(entity =>
            {
                entity.HasKey(e => new { e.IdEstudiante, e.IdPeriodo, e.IdCurso });


                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.InscripcionCurso)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull);


                entity.HasOne(d => d.Matricula)
                    .WithMany(p => p.InscripcionCurso)
                    .HasForeignKey(d => new { d.IdEstudiante, d.IdPeriodo })
                    .OnDelete(DeleteBehavior.ClientSetNull);
                   
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => new { e.IdEstudiante, e.IdPeriodo });


                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.Matricula)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull);


                entity.HasOne(d => d.Periodo)
                    .WithMany(p => p.Matricula)
                    .HasForeignKey(d => d.IdPeriodo)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Periodo>(entity =>
            {
                entity.HasKey(e => e.IdPeriodo);

                entity.Property(e => e.IdPeriodo).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
