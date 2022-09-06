using FacturadorApi.Data;
using FacturadorApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacturadorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public FacturadorDBContext _context { get; }

        public ClienteController(FacturadorDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return Ok(await _context.Cliente.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Cliente>>> Get(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
                return BadRequest("No se encontraron clientes");
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<List<Cliente>>> AddCliente(Cliente cliente)
        {
            await _context.Cliente.AddAsync(cliente); 
            _context.SaveChanges();
            return Ok(await _context.Cliente.ToListAsync());
        }
         
        [HttpPut]
        public async Task<ActionResult<List<Cliente>>> UpdateCliente(Cliente request)
        {
            var cliente = await _context.Cliente.FindAsync(request.Cli_ID);
            if (cliente == null)
                return BadRequest("No se encontraron clientes");

            cliente.RazonSocial = request.RazonSocial;
            cliente.Direccion = request.Direccion;
            cliente.CUIT = request.CUIT;
            cliente.Deshabilitado = request.Deshabilitado;

            await _context.SaveChangesAsync(); 

            return Ok(await _context.Cliente.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Cliente>>> Delete(int id)
        {
            var cliente = _context.Cliente.Find(id);
            if (cliente == null)
                return BadRequest("No se encontraron clientes");

            foreach (var factura in _context.Factura_Cabecera)
            {
                if(factura.Cli_ID == id)
                    return BadRequest("No se puede borrar, Factura Cabecera asociada al cliente");
            }
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return Ok(await _context.Cliente.ToListAsync());
        }

    }
}
