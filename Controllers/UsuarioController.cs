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
    public class UsuarioController : ControllerBase
    {
        private readonly AcademiaContext _context;

        public UsuarioController(AcademiaContext context)
        {
            _context = context;
        }

        // GET: api/<AlumnoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listUsuarios = await _context.Usuarios
                   .Include(u => u.IdRolesNavigation)  
                   .Select(u => new UsuarioDto
                   {
                       IdUsuarios = u.IdUsuarios,
                       Nombre = u.Nombre,
                       Apellidos = u.Apellidos,
                       FechaNacimiento = u.FechaNacimiento,
                       Telefono = u.Telefono,
                       Email = u.Email,
                       Contacto = u.Contacto,
                       TelefonoContacto = u.TelefonoContacto,
                       Rol = u.IdRolesNavigation != null ? u.IdRolesNavigation.Rol : null
                   })
                   .ToListAsync();

                return Ok(listUsuarios);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET: api/<AlumnoController>/instructores
        [HttpGet("instructores")]
        public async Task<IActionResult> GetInstructores()
        {
            var instructores = await _context.Usuarios
            .Where(c => c.IdRoles == 2)
            .ToListAsync();

            if (instructores == null)
            {
                return NotFound();
            }

            return Ok(instructores);
        }

        // GET api/<AlumnoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AlumnoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return Ok(new {message = "Usuario agregado exitosamente"});
            } catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AlumnoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioUpdateDto usuarioEditado)
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(r => r.IdUsuarios == id);
                if (usuario == null)
                {
                    return NotFound();
                }

                usuario.Email = usuarioEditado.Email;
                usuario.Nombre = usuarioEditado.Nombre;
                usuario.Apellidos = usuarioEditado.Apellidos;
                usuario.FechaNacimiento = usuarioEditado.FechaNacimiento;
                usuario.Telefono = usuarioEditado.Telefono;
                usuario.Contacto = usuarioEditado.Contacto;
                usuario.TelefonoContacto = usuarioEditado?.TelefonoContacto;
                usuario.IdRoles = usuarioEditado?.IdRoles;

                // Solo actualizar la contraseña si se envía en la solicitud
                if (!string.IsNullOrEmpty(usuarioEditado.Password))
                {
                    usuario.Password = usuarioEditado.Password;
                }

                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "Usuario editado exitosamente" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al actualizar usuario", error = ex.Message });
            }
        }

        // DELETE api/<AlumnoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var alumno = await _context.Usuarios.FindAsync(id);
                if (alumno == null)
                {
                    return NotFound();
                }
                _context.Usuarios.Remove(alumno);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Alumno eliminado exitosamente" });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class UsuarioDto
    {
        public int IdUsuarios { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Contacto { get; set; }
        public string? TelefonoContacto { get; set; }
        public string? Rol { get; set; } 
    }

    public class UsuarioUpdateDto
    {
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }
        public string TelefonoContacto { get; set; }
        public int IdRoles { get; set; }
        public string? Password { get; set; }
    }
}
