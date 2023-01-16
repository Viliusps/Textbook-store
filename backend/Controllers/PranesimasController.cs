using backend.data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PranesimasController : ControllerBase
    {
        private readonly DataContext _context;

        public PranesimasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pranesimas>>> Get()
        {
            return Ok(await _context.pranesimas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pranesimas>> Get(int id)
        {
            var pranesimas = await _context.pranesimas.FindAsync(id);
            if (pranesimas == null)
                return BadRequest("Pranesimas not found.");
            return Ok(pranesimas);
        }

        [HttpPost]
        public async Task<ActionResult<List<Pranesimas>>> Add(Pranesimas pranesimas)
        {
            var pranesimai = await _context.pranesimas.ToListAsync();
            int max = 0;
            foreach (Pranesimas var in pranesimai)
            {
                if (var.id > max) max = var.id;
            }
            pranesimas.id = max + 1;
            _context.pranesimas.Add(pranesimas);
            await _context.SaveChangesAsync();
            return Ok(await _context.pranesimas.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Pranesimas>>> Update(Pranesimas req)
        {
            var dbPranesimas = await _context.pranesimas.FindAsync((object)req.id);
            if (dbPranesimas == null)
                return BadRequest("Pranesimas not found.");

            dbPranesimas.id = req.id;
            dbPranesimas.pranesimo_turinys = req.pranesimo_turinys;
            dbPranesimas.issiuntimo_data = req.issiuntimo_data;
            dbPranesimas.tipas = req.tipas;
            dbPranesimas.fk_vartotojas = req.fk_vartotojas;

            await _context.SaveChangesAsync();

            return Ok(await _context.pranesimas.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Pranesimas>>> Delete(int id)
        {
            var dbPranesimas = await _context.pranesimas.FindAsync(id);
            if (dbPranesimas == null)
                return BadRequest("Pranesimas not found.");

            _context.pranesimas.Remove(dbPranesimas);
            await _context.SaveChangesAsync();
            return Ok(await _context.pranesimas.ToListAsync());
        }
    }
}
