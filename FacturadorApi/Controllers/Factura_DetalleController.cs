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
    public class Factura_DetalleController : Controller
    {
        private readonly FacturadorDBContext _context;

        public Factura_DetalleController(FacturadorDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Factura_Detalle>>> Get()
        {
            return Ok(await _context.Factura_Detalle.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Factura_Detalle>>> Get(int id)
        {
            var factura_Detalle= await _context.Factura_Detalle.FindAsync(id);
            if (factura_Detalle == null)
                return BadRequest("No se encontraron Facturas Detalle");
            return Ok(factura_Detalle);
        }

        [HttpPost]
        public async Task<ActionResult<List<Factura_Detalle>>> AddFactura_Cabecera(Factura_Detalle factura_Detalle)
        {
            var articulos = await _context.Articulo.FindAsync(factura_Detalle.Art_ID);
            if (articulos == null)
                return BadRequest("No se encontraron articulos");

            var facturas_cabecera = await _context.Factura_Cabecera.FindAsync(factura_Detalle.Fact_ID);
            if (facturas_cabecera == null)
                return BadRequest("No se encontraron facturas cabecera");

            await _context.Factura_Detalle.AddAsync(factura_Detalle);
            _context.SaveChanges();
            return Ok(await _context.Factura_Detalle.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Factura_Detalle>>> UpdateFactura_Cabecera(Factura_Detalle request)
        {
            var factura_Detalle = await _context.Factura_Detalle.FindAsync(request.FC_DTL_ID);
            if (factura_Detalle == null)
                return BadRequest("No se encontraron Facturas Cabeceras");

            var articulos = await _context.Articulo.FindAsync(request.Art_ID);
            if (articulos == null)
                return BadRequest("No se encontraron articulos");

            var facturas_cabecera = await _context.Factura_Cabecera.FindAsync(request.Fact_ID);
            if (facturas_cabecera == null)
                return BadRequest("No se encontraron facturas cabecera");

            factura_Detalle.FechaAlta = request.FechaAlta;
            factura_Detalle.Cant = request.Cant;
            factura_Detalle.Precio = request.Precio;
            factura_Detalle.Monto = request.Monto;
            factura_Detalle.Fact_ID = request.Fact_ID;
            factura_Detalle.Art_ID = request.Art_ID;

            await _context.SaveChangesAsync();

            return Ok(await _context.Factura_Detalle.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Factura_Detalle>>> Delete(int id)
        {
            var factura_Detalle = _context.Factura_Detalle.Find(id);
            if (factura_Detalle == null)
                return BadRequest("No se encontraron Facturas Cabeceras");


            _context.Factura_Detalle.Remove(factura_Detalle);
            await _context.SaveChangesAsync();

            return Ok(await _context.Factura_Detalle.ToListAsync());
        }

    }
}
