using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlumnoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
