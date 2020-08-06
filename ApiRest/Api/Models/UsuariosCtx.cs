using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class UsuariosCtx : DbContext
    {
        public UsuariosCtx(DbContextOptions<UsuariosCtx> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
