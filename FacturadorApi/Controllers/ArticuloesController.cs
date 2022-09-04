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
    public class ArticulosController : Controller
    {
        private readonly FacturadorDBContext _context;

        public ArticulosController(FacturadorDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Articulo>>> Get()
        {
            return Ok(await _context.Articulo.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<Articulo>>> Get(int id)
        {
            var articulo = await _context.Articulo.FindAsync(id);
            if (articulo == null)
                return BadRequest("No se encontraron Articulos");
            return Ok(articulo);
        }

        [HttpPost]
        public async Task<ActionResult<List<Articulo>>> AddArticulo(Articulo articulo)
        {
            await _context.Articulo.AddAsync(articulo);
            _context.SaveChanges();
            return Ok(await _context.Articulo.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Articulo>>> UpdateArticulo(Articulo request)
        {
            var articulo = await _context.Articulo.FindAsync(request.Art_id);
            if (articulo == null)
                return BadRequest("No se encontraron Articulos");

            articulo.Descripcion = request.Descripcion;
            articulo.NombreArticulo = request.NombreArticulo;
            articulo.Marca = request.Marca;

            await _context.SaveChangesAsync();

            return Ok(await _context.Articulo.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Articulo>>> Delete(int id)
        {
            var articulo = _context.Articulo.Find(id);
            if (articulo == null)
                return BadRequest("No se encontraron Articulos");
            _context.Articulo.Remove(articulo);
            await _context.SaveChangesAsync();

            return Ok(await _context.Cliente.ToListAsync());
        }
    }
}
