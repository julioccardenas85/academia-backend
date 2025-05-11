using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : Controller
    {
        private readonly AcademiaContext _context;

        public PagoController(AcademiaContext context)
        {
            _context = context;
        }

        // GET: api/<PagoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listPagos = await _context.Pagos.ToListAsync();
                return Ok(listPagos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<PagoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pago pago)
        {
            try
            {
                _context.Pagos.Add(pago);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Pago registrado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PagoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Pago pagoEditado)
        {
            try
            {
                var pago = _context.Pagos.FirstOrDefault(r => r.Id == id);
                if (pago == null)
                {
                    return NotFound();
                }

                pago.PaymentId = pagoEditado?.PaymentId;
                pago.FechaCreacion = pagoEditado?.FechaCreacion;
                pago.Monto = pagoEditado?.Monto;
                pago.Status = pagoEditado?.Status;
                pago.PaymentType = pagoEditado?.PaymentType;
                pago.EmailComprador = pagoEditado?.EmailComprador;
                pago.IdUsuarios = pagoEditado?.IdUsuarios;
                pago.Unidades = pagoEditado?.Unidades;
                pago.Concepto = pagoEditado?.Concepto;

                _context.Entry(pago).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "Pago editado exitosamente" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al actualizar pago", error = ex.Message });
            }
        }

        // DELETE api/<PagooController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pago = await _context.Pagos.FindAsync(id);
                if (pago == null)
                {
                    return NotFound();
                }
                _context.Pagos.Remove(pago);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Pago eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
