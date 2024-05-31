using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly AcademiaContext _context;

        public InstructorController(AcademiaContext context)
        {
            _context = context;
        }
        // GET: api/<InstructorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listInstructores = await _context.Instructores.ToListAsync();
                return Ok(listInstructores);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<InstructorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Instructore instructor)
        {
            try
            {
                _context.Instructores.Add(instructor);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Instructor agregado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<InstructorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Instructore instructorEditado)
        {
            try
            {
                var instructor = _context.Instructores.FirstOrDefault(r => r.Idinstructores == id);
                if (instructor == null)
                {
                    return NotFound();
                }

                instructor.Usuario = instructorEditado.Usuario;
                instructor.Nombre = instructorEditado.Nombre;
                instructor.Apellidos = instructorEditado.Apellidos;
                instructor.FechaNacimiento = instructorEditado.FechaNacimiento;
                instructor.Telefono = instructorEditado.Telefono;

                _context.Entry(instructor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "Instructor editado exitosamente" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<InstructorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var instructor = await _context.Instructores.FindAsync(id);
                if (instructor == null)
                {
                    return NotFound();
                }
                _context.Instructores.Remove(instructor);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Instructor eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
