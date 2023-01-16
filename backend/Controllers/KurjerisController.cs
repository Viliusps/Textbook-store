using backend.data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KurjerisController : ControllerBase
    {
        private readonly DataContext _context;

        public KurjerisController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Kurjeris>>> Get()
        {
            return Ok(await _context.kurjeris.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kurjeris>> Get(int id)
        {
            var kurjeris = await _context.kurjeris.FindAsync(id);
            if (kurjeris == null)
                return BadRequest("Kurjeris not found.");
            return Ok(kurjeris);
        }

        [HttpPost]
        public async Task<ActionResult<List<Kurjeris>>> Add(Kurjeris kurjeris)
        {
            var kurjeriai = await _context.kurjeris.ToListAsync();
            int max = 0;
            foreach (Kurjeris var in kurjeriai)
            {
                if (var.id > max) max = var.id;
            }
            kurjeris.id = max + 1;
            _context.kurjeris.Add(kurjeris);
            await _context.SaveChangesAsync();
            return Ok(await _context.kurjeris.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Kurjeris>>> Update(Kurjeris req)
        {
            var dbKurjeris = await _context.kurjeris.FindAsync(req.id);
            if (dbKurjeris == null)
                return BadRequest("Kurjeris not found.");

            dbKurjeris.id = req.id;
            dbKurjeris.vairuotojo_pazymejimo_galiojimo_data = req.vairuotojo_pazymejimo_galiojimo_data;
            dbKurjeris.menesio_darbo_valandos = req.menesio_darbo_valandos;
            dbKurjeris.maksimalios_menesio_darbo_valandos = req.maksimalios_menesio_darbo_valandos;
            dbKurjeris.aptarnaujama_apskritis = req.aptarnaujama_apskritis;
            dbKurjeris.fk_vartotojas = req.fk_vartotojas;

            await _context.SaveChangesAsync();

            return Ok(await _context.kurjeris.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Kurjeris>>> Delete(int id)
        {
            var dbKurjeris = await _context.kurjeris.FindAsync(id);
            if (dbKurjeris == null)
                return BadRequest("Kurjeris not found.");

            _context.kurjeris.Remove(dbKurjeris);
            await _context.SaveChangesAsync();
            return Ok(await _context.kurjeris.ToListAsync());
        }
    }
}
