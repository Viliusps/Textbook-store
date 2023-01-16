using backend.data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiuntinysController : ControllerBase
    {
        private readonly DataContext _context;

        public SiuntinysController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Siuntinys>>> Get()
        {
            return Ok(await _context.siuntinys.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Siuntinys>> Get(int id)
        {
            var siuntinys = await _context.siuntinys.FindAsync(id);
            if (siuntinys == null)
                return BadRequest("Siuntinys not found.");
            return Ok(siuntinys);
        }

        [HttpPost]
        public async Task<ActionResult<List<Siuntinys>>> Add(Siuntinys siuntinys)
        {
            var siuntiniai = await _context.siuntinys.ToListAsync();
            int max = 0;
            foreach (Siuntinys var in siuntiniai)
            {
                if (var.id > max) max = var.id;
            }
            siuntinys.id = max + 1;
            _context.siuntinys.Add(siuntinys);
            await _context.SaveChangesAsync();
            return Ok(await _context.siuntinys.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Siuntinys>>> Update(Siuntinys req)
        {
            var dbSiuntinys = await _context.siuntinys.FindAsync((object)req.id);
            if (dbSiuntinys == null)
                return BadRequest("Siuntinys not found.");

            dbSiuntinys.id = req.id;
            dbSiuntinys.kliento_vardas_pavarde = req.kliento_vardas_pavarde;
            dbSiuntinys.kliento_el_pastas = req.kliento_el_pastas;
            dbSiuntinys.kliento_telefono_nr = req.kliento_telefono_nr;
            dbSiuntinys.buvimo_vieta= req.buvimo_vieta;
            dbSiuntinys.fk_marsruto_taskas = req.fk_marsruto_taskas;
            dbSiuntinys.fk_uzsakymas = req.fk_uzsakymas;

            await _context.SaveChangesAsync();

            return Ok(await _context.siuntinys.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Siuntinys>>> Delete(int id)
        {
            var dbSiuntinys = await _context.siuntinys.FindAsync(id);
            if (dbSiuntinys == null)
                return BadRequest("Siuntinys not found.");

            _context.siuntinys.Remove(dbSiuntinys);
            await _context.SaveChangesAsync();
            return Ok(await _context.siuntinys.ToListAsync());
        }
    }
}
