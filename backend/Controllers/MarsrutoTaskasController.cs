using backend.data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarsrutoTaskasController : ControllerBase
    {
        private readonly DataContext _context;

        public MarsrutoTaskasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<marsruto_taskas>>> Get()
        {
            return Ok(await _context.marsruto_taskas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<marsruto_taskas>> Get(int id)
        {
            var marsruto_taskas = await _context.marsruto_taskas.FindAsync(id);
            if (marsruto_taskas == null)
                return BadRequest("Marsruto taskas not found.");
            return Ok(marsruto_taskas);
        }

        [HttpPost]
        public async Task<ActionResult<List<marsruto_taskas>>> Add(marsruto_taskas marsruto_taskas)
        {
            var marsruto_taskai = await _context.marsruto_taskas.ToListAsync();
            int max = 0;
            foreach (marsruto_taskas var in marsruto_taskai)
            {
                if (var.id > max) max = var.id;
            }
            marsruto_taskas.id = max + 1;
            _context.marsruto_taskas.Add(marsruto_taskas);
            await _context.SaveChangesAsync();
            return Ok(await _context.marsruto_taskas.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<marsruto_taskas>>> Update(marsruto_taskas req)
        {
            var dbMarsrutoTaskas = await _context.marsruto_taskas.FindAsync(req.id);
            if (dbMarsrutoTaskas == null)
                return BadRequest("Marsruto taskas not found.");

            dbMarsrutoTaskas.id = req.id;
            dbMarsrutoTaskas.koordinates = req.koordinates;
            dbMarsrutoTaskas.adresas = req.adresas;
            dbMarsrutoTaskas.ar_ivykdyta = req.ar_ivykdyta;
            dbMarsrutoTaskas.fk_marsrutas = req.fk_marsrutas;

            await _context.SaveChangesAsync();

            return Ok(await _context.marsruto_taskas.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<marsruto_taskas>>> Delete(int id)
        {
            var dbMarsrutoTaskas = await _context.marsruto_taskas.FindAsync(id);
            if (dbMarsrutoTaskas == null)
                return BadRequest("Marsruto taskas not found.");

            _context.marsruto_taskas.Remove(dbMarsrutoTaskas);
            await _context.SaveChangesAsync();
            return Ok(await _context.marsruto_taskas.ToListAsync());
        }
    }
}
