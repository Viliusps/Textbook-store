using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VartotojasController : ControllerBase
    {
        private readonly DataContext _context;

        public VartotojasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vartotojas>>> Get()
        {
            return Ok(await _context.vartotojas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vartotojas>> Get(int id)
        {
            var vartotojas = await _context.vartotojas.FindAsync(id);
            if (vartotojas == null)
                return BadRequest("Vartotojas not found.");
            return Ok(vartotojas);
        }

        [HttpPost]
        public async Task<ActionResult<List<Vartotojas>>> Add(Vartotojas vartotojas)
        {
            var vartotojai = await _context.vartotojas.ToListAsync();
            int max = 0;
            foreach(Vartotojas var in vartotojai)
            {
                if (var.id > max) max = var.id;
            }
            vartotojas.id = max + 1;
            _context.vartotojas.Add(vartotojas);
            
            await _context.SaveChangesAsync();
            return Ok(await _context.vartotojas.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Vartotojas>>> Update(Vartotojas req)
        {
            var dbVartotojas = await _context.vartotojas.FindAsync(req.id);
            if (dbVartotojas == null)
                return BadRequest("Vartotojas not found.");

            dbVartotojas.vardas = req.vardas;
            dbVartotojas.pavarde = req.pavarde;
            dbVartotojas.miestas = req.miestas;
            dbVartotojas.adresas = req.adresas;
            dbVartotojas.el_pastas = req.el_pastas;
            dbVartotojas.slapyvardis = req.slapyvardis;
            dbVartotojas.slaptazodis = req.slaptazodis;
            dbVartotojas.vartotojo_ivertinimas = req.vartotojo_ivertinimas;

            await _context.SaveChangesAsync();

            return Ok(await _context.vartotojas.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Vartotojas>>> Delete(int id)
        {
            var dbVartotojas = await _context.vartotojas.FindAsync(id);
            if (dbVartotojas == null)
                return BadRequest("Vartotojas not found.");

            _context.vartotojas.Remove(dbVartotojas);
            await _context.SaveChangesAsync();
            return Ok(await _context.vartotojas.ToListAsync());
        }
    }
}
