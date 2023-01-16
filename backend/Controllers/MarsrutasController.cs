using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarsrutasController : ControllerBase
    {
        private readonly DataContext _context;

        public MarsrutasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Marsrutas>>> Get()
        {
            return Ok(await _context.marsrutas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marsrutas>> Get(int id)
        {
            var kurjeris = await _context.marsrutas.FindAsync(id);
            if (kurjeris == null)
                return BadRequest("Marsrutas not found.");
            return Ok(kurjeris);
        }

        [HttpPost]
        public async Task<ActionResult<List<Marsrutas>>> Add(Marsrutas marsrutas)
        {
            var marsrutai = await _context.marsrutas.ToListAsync();
            int max = 0;
            foreach (Marsrutas var in marsrutai)
            {
                if (var.id > max) max = var.id;
            }
            marsrutas.id = max + 1;
            _context.marsrutas.Add(marsrutas);
            await _context.SaveChangesAsync();
            return Ok(await _context.marsrutas.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Marsrutas>>> Update(Marsrutas req)
        {
            var dbMarsrutas = await _context.marsrutas.FindAsync(req.id);
            if (dbMarsrutas == null)
                return BadRequest("Marsrutas not found.");

            dbMarsrutas.id = req.id;
            dbMarsrutas.numatoma_trukme = req.numatoma_trukme;
            dbMarsrutas.numatomas_atstumas = req.numatomas_atstumas;
            dbMarsrutas.siuntiniu_skaicius = req.siuntiniu_skaicius;
            dbMarsrutas.transporto_priemones_id = req.transporto_priemones_id;
            dbMarsrutas.fk_kurjeris = req.fk_kurjeris;

            await _context.SaveChangesAsync();

            return Ok(await _context.marsrutas.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Marsrutas>>> Delete(int id)
        {
            var dbMarsrutas = await _context.marsrutas.FindAsync(id);
            if (dbMarsrutas == null)
                return BadRequest("Marsrutas not found.");

            _context.marsrutas.Remove(dbMarsrutas);
            await _context.SaveChangesAsync();
            return Ok(await _context.marsrutas.ToListAsync());
        }
    }
}
