using backend.data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatistikaController : ControllerBase
    {
        private readonly DataContext _context;

        public StatistikaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Statistika>>> Get()
        {
            return Ok(await _context.statistika.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Statistika>> Get(int id)
        {
            var statistika = await _context.statistika.FindAsync(id);
            if (statistika == null)
                return BadRequest("Statistika not found.");
            return Ok(statistika);
        }

        [HttpPost]
        public async Task<ActionResult<List<Statistika>>> Add(Statistika statistika)
        {
            var statistikos = await _context.statistika.ToListAsync();
            int max = 0;
            foreach (Statistika var in statistikos)
            {
                if (var.id > max) max = var.id;
            }
            statistika.id = max + 1;
            _context.statistika.Add(statistika);
            await _context.SaveChangesAsync();
            return Ok(await _context.statistika.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Statistika>>> Update(Statistika req)
        {
            var dbStatistika = await _context.statistika.FindAsync((object)req.id);
            if (dbStatistika == null)
                return BadRequest("Statistika not found.");

            dbStatistika.id = req.id;
            dbStatistika.sudaryta = req.sudaryta;
            dbStatistika.data_nuo = req.data_nuo;
            dbStatistika.data_iki = req.data_iki;

            await _context.SaveChangesAsync();

            return Ok(await _context.statistika.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Statistika>>> Delete(int id)
        {
            var dbStatistika = await _context.statistika.FindAsync(id);
            if (dbStatistika == null)
                return BadRequest("Statistika not found.");

            _context.statistika.Remove(dbStatistika);
            await _context.SaveChangesAsync();
            return Ok(await _context.statistika.ToListAsync());
        }
    }
}
