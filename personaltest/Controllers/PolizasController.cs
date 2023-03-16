using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using personaltest.Areas.Entities;
using personaltest.Areas.Identity.Data;
using personaltest.Areas.Repositories;
using personaltest.ViewModels;

namespace personaltest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PolizasController : ControllerBase
    {
        private readonly IPolizaRepository _polizaRepository;

        public PolizasController(IPolizaRepository polizaRepository)
        {
            _polizaRepository = polizaRepository;
        }

        // GET: api/Polizas
        [HttpGet("GetPolizas")]
        public async Task<string> GetPolizas()
        {

            var data = _polizaRepository.getPolizas();
            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strData = JsonConvert.SerializeObject(data, options);

            return await Task.Run(() =>
            {
                return strData;
            });

        }

        // GET: api/Polizas/5
        [HttpGet("{id}")]
        public async Task<string> GetPoliza(int numeroPoliza, string placaAutomotor)
        {
            var data = _polizaRepository.getPoliza(numeroPoliza, placaAutomotor);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strData = JsonConvert.SerializeObject(data, options);

            return await Task.Run(() =>
            {
                return strData;
            });
        }

        // PUT: api/Polizas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutPoliza(int id, Poliza poliza)
        // {
        //     if (id != poliza.NumeroPoliza)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(poliza).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!PolizaExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // POST: api/Polizas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostPoliza")]
        public async Task<string> PostPoliza(PolizaViewModel poliza)
        {
            var response = new ResponseViewModel<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _polizaRepository.AddPolizaAsync(poliza);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // // DELETE: api/Polizas/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeletePoliza(int id)
        // {
        //     if (_context.Poliza == null)
        //     {
        //         return NotFound();
        //     }
        //     var poliza = await _context.Poliza.FindAsync(id);
        //     if (poliza == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Poliza.Remove(poliza);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool PolizaExists(int id)
        // {
        //     return (_context.Poliza?.Any(e => e.NumeroPoliza == id)).GetValueOrDefault();
        // }
    }
}
