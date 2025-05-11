using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : Controller
    {
        private readonly AcademiaContext _context;

        public RolController(AcademiaContext context)
        {
            _context = context;
        }

        // GET: api/<RolController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listRoles = await _context.Roles.ToListAsync();
                return Ok(listRoles);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<RolController>
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
    }
}
