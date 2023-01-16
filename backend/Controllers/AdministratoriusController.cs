using backend.data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratoriusController : ControllerBase
    {
        private readonly DataContext _context;

        public AdministratoriusController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Administratorius>>> Get()
        {
            return Ok(await _context.administratorius.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Administratorius>> Get(int id)
        {
            var administratorius = await _context.administratorius.FindAsync(id);
            if (administratorius == null)
                return BadRequest("Administratorius not found.");
            return Ok(administratorius);
        }

        [HttpPost]
        public async Task<ActionResult<List<Administratorius>>> Add(Administratorius administratorius)
        {
            var administratoriai = await _context.administratorius.ToListAsync();
            int max = 0;
            foreach (Administratorius var in administratoriai)
            {
                if (var.id > max) max = var.id;
            }
            administratorius.id = max + 1;
            _context.administratorius.Add(administratorius);
            await _context.SaveChangesAsync();
            return Ok(await _context.administratorius.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Administratorius>>> Update(Administratorius req)
        {
            var dbAdministratorius = await _context.administratorius.FindAsync(req.id);
            if (dbAdministratorius == null)
                return BadRequest("Administratorius not found.");

            dbAdministratorius.id = req.id;
            dbAdministratorius.administratorius_nuo = req.administratorius_nuo;
            dbAdministratorius.vartotojo_id = req.vartotojo_id;

            await _context.SaveChangesAsync();

            return Ok(await _context.administratorius.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Administratorius>>> Delete(int id)
        {
            var dbAdministratorius = await _context.administratorius.FindAsync(id);
            if (dbAdministratorius == null)
                return BadRequest("Administratorius not found.");

            _context.administratorius.Remove(dbAdministratorius);
            await _context.SaveChangesAsync();
            return Ok(await _context.administratorius.ToListAsync());
        }
    }
}
