using backend.data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PirkejasController : ControllerBase
    {
        private readonly DataContext _context;

        public PirkejasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pirkejas>>> Get()
        {
            return Ok(await _context.pirkejas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pirkejas>> Get(int id)
        {
            var pirkejas = await _context.pirkejas.FindAsync(id);
            if (pirkejas == null)
                return BadRequest("Pirkejas not found.");
            return Ok(pirkejas);
        }

        [HttpPost]
        public async Task<ActionResult<List<Pirkejas>>> Add(Pirkejas pirkejas)
        {
            var pirkejai = await _context.pirkejas.ToListAsync();
            int max = 0;
            foreach (Pirkejas var in pirkejai)
            {
                if (var.id > max) max = var.id;
            }
            pirkejas.id = max + 1;
            _context.pirkejas.Add(pirkejas);
            await _context.SaveChangesAsync();
            return Ok(await _context.pirkejas.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Pirkejas>>> Update(Pirkejas req)
        {
            var dbPirkejas = await _context.pirkejas.FindAsync((object)req.id);
            if (dbPirkejas == null)
                return BadRequest("Pirkejas not found.");

            dbPirkejas.id = req.id;
            dbPirkejas.mokejimo_metodas = req.mokejimo_metodas;
            dbPirkejas.fk_vartotojas = req.fk_vartotojas;

            await _context.SaveChangesAsync();

            return Ok(await _context.pirkejas.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Pirkejas>>> Delete(int id)
        {
            var dbPirkejas = await _context.pirkejas.FindAsync(id);
            if (dbPirkejas == null)
                return BadRequest("Pardavejas not found.");

            _context.pirkejas.Remove(dbPirkejas);
            await _context.SaveChangesAsync();
            return Ok(await _context.pirkejas.ToListAsync());
        }
    }
}
