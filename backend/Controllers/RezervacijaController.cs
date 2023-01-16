using backend.data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervacijaController : ControllerBase
    {
        private readonly DataContext _context;

        public RezervacijaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rezervacija>>> Get()
        {
            return Ok(await _context.rezervacija.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rezervacija>> Get(int id)
        {
            var rezervacija = await _context.rezervacija.FindAsync(id);
            if (rezervacija == null)
                return BadRequest("Rezervacija not found.");
            return Ok(rezervacija);
        }

        [HttpPost]
        public async Task<ActionResult<List<Rezervacija>>> Add(Rezervacija rezervacija)
        {
            var rezervacijos = await _context.rezervacija.ToListAsync();
            int max = 0;
            foreach (Rezervacija var in rezervacijos)
            {
                if (var.id > max) max = var.id;
            }
            rezervacija.id = max + 1;
            _context.rezervacija.Add(rezervacija);
            await _context.SaveChangesAsync();
            return Ok(await _context.rezervacija.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Rezervacija>>> Update(Rezervacija req)
        {
            var dbRezervacija = await _context.rezervacija.FindAsync((object)req.id);
            if (dbRezervacija == null)
                return BadRequest("Rezervacija not found.");

            dbRezervacija.id = req.id;
            dbRezervacija.pradzia = req.pradzia;
            dbRezervacija.pabaiga = req.pabaiga;
            dbRezervacija.fk_pirkejas = req.fk_pirkejas;
            dbRezervacija.fk_pardavejas = req.fk_pardavejas;

            await _context.SaveChangesAsync();

            return Ok(await _context.rezervacija.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Rezervacija>>> Delete(int id)
        {
            var dbRezervacija = await _context.rezervacija.FindAsync(id);
            if (dbRezervacija == null)
                return BadRequest("Pranesimas not found.");

            _context.rezervacija.Remove(dbRezervacija);
            await _context.SaveChangesAsync();
            return Ok(await _context.rezervacija.ToListAsync());
        }
    }
}
