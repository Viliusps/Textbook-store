using backend.data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PardavejasController : ControllerBase
    {
        private readonly DataContext _context;

        public PardavejasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pardavejas>>> Get()
        {
            return Ok(await _context.pardavejas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pardavejas>> Get(int id)
        {
            var pardavejas = await _context.pardavejas.FindAsync(id);
            if (pardavejas == null)
                return BadRequest("Pardavejas not found.");
            return Ok(pardavejas);
        }

        [HttpPost]
        public async Task<ActionResult<List<Pardavejas>>> Add(Pardavejas pardavejas)
        {
            var pardavejai = await _context.pardavejas.ToListAsync();
            int max = 0;
            foreach (Pardavejas var in pardavejai)
            {
                if (var.id > max) max = var.id;
            }
            pardavejas.id = max + 1;
            _context.pardavejas.Add(pardavejas);
            await _context.SaveChangesAsync();
            return Ok(await _context.pardavejas.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Pardavejas>>> Update(Pardavejas req)
        {
            var dbPardavejas = await _context.pardavejas.FindAsync((object)req.id);
            if (dbPardavejas == null)
                return BadRequest("Pardavejas not found.");

            dbPardavejas.id = req.id;
            dbPardavejas.banko_saskaitos_numeris = req.banko_saskaitos_numeris;
            dbPardavejas.fk_vartotojas = req.fk_vartotojas;

            await _context.SaveChangesAsync();

            return Ok(await _context.pardavejas.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Pardavejas>>> Delete(int id)
        {
            var dbPardavejas = await _context.pardavejas.FindAsync(id);
            if (dbPardavejas == null)
                return BadRequest("Pardavejas not found.");

            _context.pardavejas.Remove(dbPardavejas);
            await _context.SaveChangesAsync();
            return Ok(await _context.pardavejas.ToListAsync());
        }
    }
}
