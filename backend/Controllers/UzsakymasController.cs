using backend.data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UzsakymasController : ControllerBase
    {
        private readonly DataContext _context;

        public UzsakymasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Uzsakymas>>> Get()
        {
            return Ok(await _context.uzsakymas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Uzsakymas>> Get(int id)
        {
            var uzsakymas = await _context.uzsakymas.FindAsync(id);
            if (uzsakymas == null)
                return BadRequest("Uzsakymas not found.");
            return Ok(uzsakymas);
        }

        [HttpPost]
        public async Task<ActionResult<List<Uzsakymas>>> Add(Uzsakymas uzsakymas)
        {
            var uzsakymai = await _context.uzsakymas.ToListAsync();
            int max = 0;
            foreach (Uzsakymas var in uzsakymai)
            {
                if (var.id > max) max = var.id;
            }
            uzsakymas.id = max + 1;
            _context.uzsakymas.Add(uzsakymas);
            await _context.SaveChangesAsync();
            return Ok(await _context.uzsakymas.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Uzsakymas>>> Update(Uzsakymas req)
        {
            var dbUzsakymas = await _context.uzsakymas.FindAsync((object)req.id);
            if (dbUzsakymas == null)
                return BadRequest("Uzsakymas not found.");

            dbUzsakymas.id = req.id;
            dbUzsakymas.data = req.data;
            dbUzsakymas.fk_pirkejas = req.fk_pirkejas;

            await _context.SaveChangesAsync();

            return Ok(await _context.uzsakymas.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Uzsakymas>>> Delete(int id)
        {
            var dbUzsakymas = await _context.uzsakymas.FindAsync(id);
            if (dbUzsakymas == null)
                return BadRequest("Uzsakymas not found.");

            _context.uzsakymas.Remove(dbUzsakymas);
            await _context.SaveChangesAsync();
            return Ok(await _context.uzsakymas.ToListAsync());
        }
    }
}
