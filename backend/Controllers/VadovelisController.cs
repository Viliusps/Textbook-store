using backend.data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VadovelisController : ControllerBase
    {
        private readonly DataContext _context;

        public VadovelisController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vadovelis>>> Get()
        {
            return Ok(await _context.vadovelis.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vadovelis>> Get(int id)
        {
            var vadovelis = await _context.vadovelis.FindAsync(id);
            if (vadovelis == null)
                return BadRequest("Vadovelis not found.");
            return Ok(vadovelis);
        }

        [HttpPost]
        public async Task<ActionResult<List<Vadovelis>>> Add(Vadovelis vadovelis)
        {
            var vadoveliai = await _context.vadovelis.ToListAsync();
            int max = 0;
            foreach (Vadovelis var in vadoveliai)
            {
                if (var.id > max) max = var.id;
            }
            vadovelis.id = max + 1;
            _context.vadovelis.Add(vadovelis);
            await _context.SaveChangesAsync();
            return Ok(await _context.vadovelis.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Vadovelis>>> Update(Vadovelis req)
        {
            var dbVadovelis = await _context.vadovelis.FindAsync((object)req.id);
            if (dbVadovelis == null)
                return BadRequest("Vadovelis not found.");

            dbVadovelis.id = req.id;
            dbVadovelis.pavadinimas = req.pavadinimas;
            dbVadovelis.puslapiu_skaicius = req.puslapiu_skaicius;
            dbVadovelis.isbn = req.isbn;
            dbVadovelis.fk_populiarumas=req.fk_populiarumas;
            dbVadovelis.aprasymas=req.aprasymas;
            dbVadovelis.leidejas=req.leidejas;
            dbVadovelis.metai=req.metai;
            dbVadovelis.kalba=req.kalba;

            await _context.SaveChangesAsync();

            return Ok(await _context.vadovelis.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Vadovelis>>> Delete(int id)
        {
            var dbVadovelis = await _context.vadovelis.FindAsync(id);
            if (dbVadovelis == null)
                return BadRequest("Vadovelis not found.");

            _context.vadovelis.Remove(dbVadovelis);
            await _context.SaveChangesAsync();
            return Ok(await _context.vadovelis.ToListAsync());
        }
    }
}
