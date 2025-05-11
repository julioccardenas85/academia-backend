using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {

        private readonly AcademiaContext _context;

        public AgendaController(AcademiaContext context)
        {
            _context = context;
        }

        // GET: api/<AgendaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listAgenda = await _context.Agenda.ToListAsync();
                return Ok(listAgenda);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<AgendaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Agendum agendum)
        {
            try
            {
                _context.Agenda.Add(agendum);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Evento agregado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AgendaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Agendum agendumEditado)
        {
            try
            {
                var agendum = _context.Agenda.FirstOrDefault(r => r.IdAgenda == id);
                if (agendum == null)
                {
                    return NotFound();
                }

                agendum.Title = agendumEditado.Title;
                agendum.Start = agendumEditado.Start;
                agendum.End = agendumEditado.End;
                agendum.AllDay = agendumEditado.AllDay;
                agendum.Color = agendumEditado.Color;

                _context.Entry(agendum).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "Evento editado exitosamente" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AgendaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var agendum = await _context.Agenda.FindAsync(id);
                if (agendum == null)
                {
                    return NotFound();
                }
                _context.Agenda.Remove(agendum);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Evento eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
