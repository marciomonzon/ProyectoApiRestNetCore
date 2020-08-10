using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cursos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly CursosCTX _ctx;

        public EstudiantesController(CursosCTX ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IEnumerable<Estudiante>> Get()
        {
            return await _ctx.Estudiante.ToListAsync();
        }

        // Estudiante/2/4
        [HttpGet("{id}/{codigo}", Name = "GetEstudiante")] // para el createdAtRoute y el createdAtAction
        // Estudiante/2
        // [HttpGet("{id}"]
        public async Task<IActionResult> Get(int id, string codigo)
        {
            var estudiante = await _ctx.Estudiante.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return Ok(estudiante);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _ctx.Estudiante.Add(estudiante);
            await _ctx.SaveChangesAsync();

            return CreatedAtRoute("GetEstudiante", new { Id = estudiante.IdEstudiante, Codigo = estudiante.Codigo }, estudiante);
            //return CreatedAtAction(nameof(Get), new { Id = estudiante.IdEstudiante, Codigo = estudiante.Codigo }, estudiante);
            //return Created($"/Estudiante/{estudiante.Codigo}", estudiante);
        }
    }
}