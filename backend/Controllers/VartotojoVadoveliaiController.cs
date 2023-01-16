using backend.data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VartotojoVadoveliaiController : ControllerBase
    {
        private readonly DataContext _context;

        public VartotojoVadoveliaiController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<vartotojo_parduodami_vadoveliai>>> Get()
        {
            return Ok(await _context.vartotojo_parduodami_vadoveliai.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<vartotojo_parduodami_vadoveliai>> Get(int id)
        {
            var vadovelis = await _context.vartotojo_parduodami_vadoveliai.FindAsync(id);
            if (vadovelis == null)
                return BadRequest("Vartotojo vadovelis not found.");
            return Ok(vadovelis);
        }

        [HttpPost]
        public async Task<ActionResult<List<vartotojo_parduodami_vadoveliai>>> Add(vartotojo_parduodami_vadoveliai vadovelis)
        {
            var vadoveliai = await _context.vartotojo_parduodami_vadoveliai.ToListAsync();
            int max = 0;
            foreach (vartotojo_parduodami_vadoveliai var in vadoveliai)
            {
                if (var.id > max) max = var.id;
            }
            vadovelis.id = max + 1;
            _context.vartotojo_parduodami_vadoveliai.Add(vadovelis);
            await _context.SaveChangesAsync();
            return Ok(await _context.vartotojo_parduodami_vadoveliai.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<vartotojo_parduodami_vadoveliai>>> Update(vartotojo_parduodami_vadoveliai req)
        {
            var dbVadovelis = await _context.vartotojo_parduodami_vadoveliai.FindAsync((object)req.id);
            if (dbVadovelis == null)
                return BadRequest("Vadovelis not found.");

            dbVadovelis.id = req.id;
            dbVadovelis.kaina = req.kaina;
            dbVadovelis.bukle = req.bukle;
            dbVadovelis.fk_pardavejas=req.fk_pardavejas;
            dbVadovelis.fk_vadovelis=req.fk_vadovelis;
            dbVadovelis.fk_uzsakymas=req.fk_uzsakymas;

            await _context.SaveChangesAsync();

            return Ok(await _context.vartotojo_parduodami_vadoveliai.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<vartotojo_parduodami_vadoveliai>>> Delete(int id)
        {
            var dbVadovelis = await _context.vartotojo_parduodami_vadoveliai.FindAsync(id);
            if (dbVadovelis == null)
                return BadRequest("Vadovelis not found.");

            _context.vartotojo_parduodami_vadoveliai.Remove(dbVadovelis);
            await _context.SaveChangesAsync();
            return Ok(await _context.vartotojo_parduodami_vadoveliai.ToListAsync());
        }
    }
}
