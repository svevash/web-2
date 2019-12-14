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
    }
}