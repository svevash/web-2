using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using System.Threading.Tasks;
 
namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToysController : ControllerBase
    {
        ToyContext db;
        public ToysController(ToyContext context)
        {
            db = context;
            if (!db.Toys.Any())
            {
                db.Toys.Add(new Toy { Name = "Tom", Material = "cotton", Price = 5});
                db.Toys.Add(new Toy { Name = "Alice", Material = "silk", Price = 6});
                db.SaveChanges();
            }
        }
 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Toy>>> Get()
        {
            return await db.Toys.ToListAsync();
        }
 
        // GET api/toys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Toy>> Get(int id)
        {
            Toy toy = await db.Toys.FirstOrDefaultAsync(x => x.Id == id);
            if (toy == null)
                return NotFound();
            return new ObjectResult(toy);
        }
 
        // POST api/toys
        [HttpPost]
        public async Task<ActionResult<Toy>> Post(Toy toy)
        {
            if (toy == null)
            {
                return BadRequest();
            }
 
            db.Toys.Add(toy);
            await db.SaveChangesAsync();
            return Ok(toy);
        }
 
        // PUT api/toys/
        [HttpPut]
        public async Task<ActionResult<Toy>> Put(Toy toy)
        {
            if (toy == null)
            {
                return BadRequest();
            }
            if (!db.Toys.Any(x => x.Id == toy.Id))
            {
                return NotFound();
            }
 
            db.Update(toy);
            await db.SaveChangesAsync();
            return Ok(toy);
        }
 
        // DELETE api/toys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Toy>> Delete(int id)
        {
            Toy toy = db.Toys.FirstOrDefault(x => x.Id == id);
            if (toy == null)
            {
                return NotFound();
            }
            db.Toys.Remove(toy);
            await db.SaveChangesAsync();
            return Ok(toy);
        }
    }
}