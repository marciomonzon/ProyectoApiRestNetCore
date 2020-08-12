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
            // el net core tiene, implicitamente, una validacion del model de forma automatica.
            // es posible sacar eso en el startup.cs
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorHelper.GetModelStateErrors(ModelState));
            }

            _ctx.Estudiante.Add(estudiante);
            await _ctx.SaveChangesAsync();

            return CreatedAtRoute("GetEstudiante", new { Id = estudiante.IdEstudiante, Codigo = estudiante.Codigo }, estudiante);
            //return CreatedAtAction(nameof(Get), new { Id = estudiante.IdEstudiante, Codigo = estudiante.Codigo }, estudiante);
            //return Created($"/Estudiante/{estudiante.Codigo}", estudiante);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Estudiante estudiante)
        {
            if (estudiante.IdEstudiante == 0)
            {
                estudiante.IdEstudiante = id;
            }

            if (id != estudiante.IdEstudiante)
            {
                return BadRequest(ErrorHelper.Response(400 , "Peticion no válida."));
            }

            var result = await _ctx.Estudiante.FindAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _ctx.Entry(estudiante).State = EntityState.Modified;
            if (!TryValidateModel(estudiante, nameof(estudiante)))
            {
                return BadRequest(ErrorHelper.GetModelStateErrors(ModelState));
            }

            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estudiante = await _ctx.Estudiante.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            _ctx.Estudiante.Remove(estudiante);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }

    }
}