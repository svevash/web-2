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
                var toy1 = new Toy { Name = "Grumpy Cat", Material = "cotton", Price = 599 };
                var toy2 = new Toy { Name = "Tom The Cat", Material = "cotton", Price = 499 };
                var toy3 = new Toy { Name = "Jerry The Mouse", Material = "synthetics", Price = 599 };
                var toy4 = new Toy { Name = "Mickey Mouse", Material = "plastic", Price = 1099 };
                var toy5 = new Toy { Name = "Minnie Mouse", Material = "plastic", Price = 399 };
                var toy6 = new Toy { Name = "Barbie", Material = "plastic", Price = 299 };
                var toy7 = new Toy { Name = "Ken", Material = "plastic", Price = 1199 };
                var toy8 = new Toy { Name = "Blue Sad Dog", Material = "cotton", Price = 899 };
                var toy9 = new Toy { Name = "Star Wars", Material = "plastic", Price = 199 };
                var toy10 = new Toy { Name = "Ninjago", Material = "plastic", Price = 299 };

                var mat1 = new Material { Name = "cotton" };
                var mat2 = new Material { Name = "synthetic" };
                var mat3 = new Material {Name = "plastic"};
                
                db.Materials.AddRange(mat1, mat2, mat3);
                db.Toys.AddRange(toy1, toy2, toy3, toy4, toy5, toy6, toy7, toy8, toy9, toy10);
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