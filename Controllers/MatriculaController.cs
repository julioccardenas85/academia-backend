using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly AcademiaContext _context;

        public MatriculaController(AcademiaContext context)
        {
            _context = context;
        }
        // GET: api/MatriculaController/{id}
        [HttpGet("api/[controller]/{id}")]
        public async Task<IActionResult> GetMatriculasByGrupo(int id)
        {
            var matriculas = await _context.MatriculasViews
            .Where(c => c.IdGrupos == id)
            .ToListAsync();

            if (matriculas == null)
            {
                return NotFound();
            }

            return Ok(matriculas);
        }
        
        [HttpGet("api/[controller]/alumnosNoInscritos/{id}")]
        public async Task<IActionResult> GetAlumnosNoInscritos(int id)
        {
            var matriculasInscritas = await _context.MatriculasViews
                .Where(c => c.IdGrupos == id)
                .Select(m => m.IdUsuarios)
                .Distinct()
                .ToListAsync();

            var matriculasNoInscritas = await _context.MatriculasViews
                .Where(m => !matriculasInscritas.Contains(m.IdUsuarios))
                .GroupBy(m => m.IdUsuarios) 
                .Select(g => g.FirstOrDefault()) 
                .ToListAsync();

            if (matriculasNoInscritas == null || !matriculasNoInscritas.Any())
            {
                return NotFound();
            }

            return Ok(matriculasNoInscritas);
        }

        [HttpPost("api/[controller]/inscribir")]
        public async Task<IActionResult> InscribirAlumno([FromBody] MatriculaRequest request)
        {
            var existeMatricula = await _context.Matriculas
                .AnyAsync(m => m.IdUsuarios == request.IdUsuario && m.IdGrupos == request.IdGrupo);

            if (existeMatricula)
            {
                return BadRequest("El alumno ya está inscrito en este grupo.");
            }

            var nuevaMatricula = new Matricula
            {
                IdUsuarios = request.IdUsuario,
                IdGrupos = request.IdGrupo,
            };

            _context.Matriculas.Add(nuevaMatricula);
            await _context.SaveChangesAsync();

            return Ok("Alumno inscrito correctamente.");
        }

        [HttpPost("api/[controller]/eliminar")]
        public async Task<IActionResult> EliminarAlumno([FromBody] MatriculaRequest request)
        {
            var matricula = await _context.Matriculas
                .FirstOrDefaultAsync(m => m.IdUsuarios == request.IdUsuario && m.IdGrupos == request.IdGrupo);

            if (matricula == null)
            {
                return BadRequest("El alumno no está inscrito en este grupo.");
            }

            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();

            return Ok("Alumno eliminado correctamente del grupo.");
        }

        public class MatriculaRequest
        {
            public int IdUsuario { get; set; }
            public int IdGrupo { get; set; }
        }

    }
}
