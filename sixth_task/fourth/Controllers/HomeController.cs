using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using fourth.Models;
using Microsoft.EntityFrameworkCore;

namespace fourth.Controllers
{
    public class HomeController : Controller
    {
        ToyContext db;
        public HomeController(ToyContext context)
        {
            db = context;
            // добавляем начальные данные
            if (db.Types.Count() != 0) return;
            var cat = new ToyType { Name = "cat" };
            var lego = new ToyType { Name = "lego" };
            var dog = new ToyType { Name = "dog" };
            var mouse = new ToyType { Name = "mouse" };
            var doll = new ToyType { Name = "doll" };

            var toy1 = new Toy { Name = "Grumpy Cat", Type = cat, Price = 599 };
            var toy2 = new Toy { Name = "Tom The Cat", Type = cat, Price = 499 };
            var toy3 = new Toy { Name = "Jerry The Mouse", Type = mouse, Price = 599 };
            var toy4 = new Toy { Name = "Mickey Mouse", Type = mouse, Price = 1099 };
            var toy5 = new Toy { Name = "Minnie Mouse", Type = mouse, Price = 399 };
            var toy6 = new Toy { Name = "Barbie", Type = doll, Price = 299 };
            var toy7 = new Toy { Name = "Ken", Type = doll, Price = 1199 };
            var toy8 = new Toy { Name = "Blue Sad Dog", Type = dog, Price = 899 };
            var toy9 = new Toy { Name = "Star Wars", Type = lego, Price = 199 };
            var toy10 = new Toy { Name = "Ninjago", Type = lego, Price = 299 };

            db.Types.AddRange(cat, dog, lego, mouse, doll);
            db.Toys.AddRange(toy1, toy2, toy3, toy4, toy5, toy6, toy7, toy8, toy9, toy10);
            db.SaveChanges();
        }

        // жадная загрузка
        public IActionResult EagerLoadingIndex()
        {
            var toys = db.Toys
                    .Include(x => x.Type)
                    .ToList();
            return View(toys.ToList());
        }

        // явная загрузка
        public IActionResult ExplicitLoadingIndex()
        {
            db.Toys.Load();
            db.Types.Load();
            return View(db.Toys.ToList());
        }

        // ленивая загрузка
        public IActionResult LazyLoadingIndex()
        {
            var toys = db.Toys.ToList();
            return View(toys);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
