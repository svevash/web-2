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
        ShopContext db;
        public HomeController(ShopContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Toys.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Toy toy)
        {
            db.Toys.Add(toy);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var toy = await db.Toys.FindAsync(id);

            if (toy == null) return RedirectToAction("Index");
            
            db.Toys.Remove(toy);
            await db.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }

        private Toy toy;
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            toy = await db.Toys.FindAsync(id);
 
            if (toy == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");;
        }
        public async Task<IActionResult> Edit()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
 
            db.Attach(toy).State = EntityState.Modified;
 
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!db.Toys.Any(e => e.Id == toy.Id))
                {
                    return NotFound();
                }
                throw;
            }
            return RedirectToPage("Index");
        }
    }
}