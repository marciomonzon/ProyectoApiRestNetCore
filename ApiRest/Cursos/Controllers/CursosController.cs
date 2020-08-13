using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cursos.Helper;
using Cursos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly CursosCTX _ctx;

        public CursosController(CursosCTX ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IEnumerable<Curso>> Get()
        {
            return await _ctx.Curso.ToListAsync();
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> Get(int id)
        {
            var curso = await _ctx.Curso.FindAsync(id);

            if (curso == null)
            {
                return NotFound(ErrorHelper.Response(404, $"Curso {id} no encontrado."));
            }

            return Ok(curso);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorHelper.GetModelStateErrors(ModelState));
            }

            if (await _ctx.Curso.Where(x => x.IdCurso == curso.IdCurso).AnyAsync())
            {
                return BadRequest(ErrorHelper.Response(400, $"El id del curso {curso.IdCurso} yá existe!"));
            }

            if (await _ctx.Curso.Where(x => x.Codigo == curso.Codigo).AnyAsync())
            {
                return BadRequest(ErrorHelper.Response(400, $"El código {curso.Codigo} yá existe!"));
            }

            curso.Estado = curso.Estado ?? true; // por default es true
            _ctx.Curso.Add(curso);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = curso.IdCurso }, curso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Curso curso)
        {
            if (curso.IdCurso == 0)
            {
                curso.IdCurso = id;
            }

            if (curso.IdCurso != id)
            {
                return BadRequest(ErrorHelper.Response(400, "Peticion no válida"));
            }

            if (!await _ctx.Curso.Where(x => x.Codigo == curso.Codigo).AsNoTracking().AnyAsync())
            {
                return BadRequest(ErrorHelper.Response(400, $"El código {curso.Codigo} yá existe!"));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorHelper.GetModelStateErrors(ModelState));
            }

            _ctx.Entry(curso).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return NoContent();
        }
    }
}