using backend.data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopuliarumasController : ControllerBase
    {
        private readonly DataContext _context;

        public PopuliarumasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Populiarumas>>> Get()
        {
            return Ok(await _context.populiarumas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Populiarumas>> Get(int id)
        {
            var populiarumas = await _context.populiarumas.FindAsync(id);
            if (populiarumas == null)
                return BadRequest("Populiarumas not found.");
            return Ok(populiarumas);
        }

        [HttpPost]
        public async Task<ActionResult<List<Populiarumas>>> Add(Populiarumas populiarumas)
        {
            var populiarumai = await _context.populiarumas.ToListAsync();
            int max = 0;
            foreach (Populiarumas var in populiarumai)
            {
                if (var.id > max) max = var.id;
            }
            populiarumas.id = max + 1;
            _context.populiarumas.Add(populiarumas);
            await _context.SaveChangesAsync();
            return Ok(await _context.populiarumas.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Populiarumas>>> Update(Populiarumas req)
        {
            var dbPopuliarumas = await _context.populiarumas.FindAsync((object)req.id);
            if (dbPopuliarumas == null)
                return BadRequest("Populiarumas not found.");

            dbPopuliarumas.id = req.id;
            dbPopuliarumas.pop_skaicius = req.pop_skaicius;
            dbPopuliarumas.isbn = req.isbn;

            await _context.SaveChangesAsync();

            return Ok(await _context.populiarumas.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Populiarumas>>> Delete(int id)
        {
            var dbPopuliarumas = await _context.populiarumas.FindAsync(id);
            if (dbPopuliarumas == null)
                return BadRequest("Populiarumas not found.");

            _context.populiarumas.Remove(dbPopuliarumas);
            await _context.SaveChangesAsync();
            return Ok(await _context.populiarumas.ToListAsync());
        }
    }
}
