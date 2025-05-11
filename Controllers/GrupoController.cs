using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly AcademiaContext _context;

        public GrupoController(AcademiaContext context)
        {
            _context = context;
        }
        // GET: api/<GrupoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listGrupos = await _context.GruposViews.ToListAsync();
                return Ok(listGrupos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<GrupoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Grupo grupo)
        {
            try
            {
                _context.Grupos.Add(grupo);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Grupo agregado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<GrupoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Grupo grupoEditado)
        {
            try
            {
                var grupo = _context.Grupos.FirstOrDefault(r => r.Idgrupos == id);
                if (grupo == null)
                {
                    return NotFound();
                }

                grupo.Nombre = grupoEditado.Nombre;
                grupo.IdInstructores = grupoEditado.IdInstructores;

                _context.Entry(grupo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "Grupo editado exitosamente" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<GrupoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var grupo = await _context.Grupos.FindAsync(id);
                if (grupo == null)
                {
                    return NotFound();
                }
                _context.Grupos.Remove(grupo);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Grupo eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
