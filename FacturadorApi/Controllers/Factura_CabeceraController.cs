using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FacturadorApi.Data;
using FacturadorApi.Model;

namespace FacturadorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Factura_CabeceraController : Controller
    {
        private readonly FacturadorDBContext _context;

        public Factura_CabeceraController(FacturadorDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Factura_Cabecera>>> Get()
        {
            return Ok(await _context.Factura_Cabecera.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Factura_Cabecera>>> Get(int id)
        {
            var factura_Cabecera = await _context.Factura_Cabecera.FindAsync(id);
            if (factura_Cabecera == null)
                return BadRequest("No se encontraron Facturas Cabeceras");
            return Ok(factura_Cabecera);
        }

        [HttpPost]
        public async Task<ActionResult<List<Factura_Cabecera>>> AddFactura_Cabecera(Factura_Cabecera Factura_Cabecera)
        {
            var cliente = await _context.Cliente.FindAsync(Factura_Cabecera.Cli_ID);
            if (cliente == null)
                return BadRequest("No se encontraron clientes");

            await _context.Factura_Cabecera.AddAsync(Factura_Cabecera);
            _context.SaveChanges();
            return Ok(await _context.Factura_Cabecera.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Factura_Cabecera>>> UpdateFactura_Cabecera(Factura_Cabecera request)
        {
            var Factura_Cabecera = await _context.Factura_Cabecera.FindAsync(request.FC_ID);
            if (Factura_Cabecera == null)
                return BadRequest("No se encontraron Facturas Cabeceras");

            var cliente = await _context.Cliente.FindAsync(request.Cli_ID);
            if (cliente == null)
                return BadRequest("No se encontraron clientes");

            Factura_Cabecera.FechaAlta = request.FechaAlta;
            Factura_Cabecera.Estado = request.Estado;
            Factura_Cabecera.Cli_ID = request.Cli_ID;

            await _context.SaveChangesAsync();

            return Ok(await _context.Factura_Cabecera.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Factura_Cabecera>>> Delete(int id)
        {
            var Factura_Cabecera = _context.Factura_Cabecera.Find(id);
            if (Factura_Cabecera == null)
                return BadRequest("No se encontraron Facturas Cabeceras");

            foreach (var factura in _context.Factura_Detalle)
            {
                if (factura.Fact_ID == id)
                    return BadRequest("No se puede borrar, Factura Detalle asociada al factura cabecera");
            }

            _context.Factura_Cabecera.Remove(Factura_Cabecera);
            await _context.SaveChangesAsync();

            return Ok(await _context.Factura_Cabecera.ToListAsync());
        }


    }
}
