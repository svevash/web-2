using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ToyShop.Models;

namespace ToyShop.Controllers
{
    public class HomeController : Controller
    {
        readonly ShopContext _db;
        public HomeController(ShopContext context)
        {
            _db = context;
            if (_db.Toys.Any()) return;
            ToyType t1 = new ToyType {Name = "kitten"};
            ToyType t2 = new ToyType {Name = "car"};
            ToyType t3 = new ToyType {Name = "lego"};
            ToyType t4 = new ToyType {Name = "dog"};
            ToyType t5 = new ToyType {Name = "mouse"};
                
            Toy toy1 = new Toy{Name = "Jerry", Type = t5, CreationDate = DateTime.Now, Price = 100};
            Toy toy2 = new Toy{Name = "Tom", Type = t1, CreationDate = DateTime.Now, Price = 200};
            Toy toy3 = new Toy{Name = "Pain", Type = t2, CreationDate = DateTime.Now, Price = 300};
            Toy toy4 = new Toy{Name = "Emo", Type = t4, CreationDate = DateTime.Now, Price = 400};
            Toy toy5 = new Toy{Name = "StarWars", Type = t3, CreationDate = DateTime.Now, Price = 500};
            Toy toy6 = new Toy{Name = "Ninjago", Type = t3, CreationDate = DateTime.Now, Price = 600};
            Toy toy7 = new Toy{Name = "Mickey", Type = t5, CreationDate = DateTime.Now, Price = 500};
            Toy toy8 = new Toy{Name = "Sailer", Type = t1, CreationDate = DateTime.Now, Price = 800};
            Toy toy9 = new Toy{Name = "Bob", Type = t2, CreationDate = DateTime.Now, Price = 900};
            Toy toy10 = new Toy{Name = "Bobik", Type = t4, CreationDate = DateTime.Now, Price = 300};
            Toy toy11 = new Toy{Name = "House", Type = t3, CreationDate = DateTime.Now, Price = 500};
                
            _db.Types.AddRange(t1, t2, t3, t4);
            _db.Toys.AddRange(toy1, toy2, toy3, toy4, toy5, toy6, toy7, toy8, toy9, toy10, toy11);
            _db.SaveChanges();
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _db.Toys.ToListAsync());
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Toy toy)
        {
            _db.Toys.Add(toy);
            _db.Types.Add(toy.Type);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
