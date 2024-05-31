using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly AcademiaContext _context;

        public AlumnoController(AcademiaContext context)
        {
            _context = context;
        }

        // GET: api/<AlumnoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listAlumnos = await _context.Alumnos.ToListAsync();
                return Ok(listAlumnos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<AlumnoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AlumnoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Alumno alumno)
        {
            try
            {
                _context.Alumnos.Add(alumno);
                await _context.SaveChangesAsync();
                return Ok(new {message = "Alumno agregado exitosamente"});
            } catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AlumnoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Alumno alumnoEditado)
        {
            try
            {
                var alumno = _context.Alumnos.FirstOrDefault(r => r.Idalumnos == id);
                if (alumno == null)
                {
                    return NotFound();
                }

                alumno.User = alumnoEditado.User;
                alumno.Nombre = alumnoEditado.Nombre;
                alumno.Apellidos = alumnoEditado.Apellidos;
                alumno.FechaNacimiento = alumnoEditado.FechaNacimiento;
                alumno.Telefono = alumnoEditado.Telefono;
                alumno.Contacto = alumnoEditado.Contacto;
                alumno.TelefonoContacto = alumnoEditado?.TelefonoContacto;

                _context.Entry(alumno).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "Alumno editado exitosamente" });

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AlumnoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var alumno = await _context.Alumnos.FindAsync(id);
                if (alumno == null)
                {
                    return NotFound();
                }
                _context.Alumnos.Remove(alumno);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Alumno eliminado exitosamente" });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
