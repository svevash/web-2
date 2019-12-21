using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToyShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace ToyShop.Controllers
{
    public class ToyController : Controller
    {
        readonly ShopContext db;
        public ToyController(ShopContext context)
        {
            db = context;
        }
        
        public IActionResult Index(string text)
        {
            if (text == null || text.Trim() == "") return View(db.Toys.ToList());
            var toys = db.Toys.Where(c => c.Name.Contains(text) || 
                                          c.Type.Contains(text) ||
                                          c.Price.ToString().Contains(text));
            return View(toys);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Toy toy)
        {
            db.Toys.Add(toy); 
            db.SaveChanges();
            return View();
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null) {
                return new BadRequestResult();
            }
            
            var toy = db.Toys.Find(Id);
            
            if (toy == null) {
                return new NotFoundResult();
            }
            db.Toys.Remove(db.Toys.Find(Id));
            db.SaveChanges();
            
            return Redirect("/Toy/Index");
        }

        public IActionResult Detail(int ? Id)
        {
            if (Id == null) {
                return new BadRequestResult();
            }
            
            var toy = db.Toys.Find(Id);
            if (toy == null) {
                return new NotFoundResult();
            }

            ViewBag.Name = toy.Name;
            ViewBag.Type = toy.Type;
            ViewBag.Price = toy.Price;
            
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int ? Id)
        {
            if (Id == null) {
                return new BadRequestResult();
            }
            
            var toy = db.Toys.Find(Id);
            if (toy == null) {
                return new NotFoundResult();
            }

            ViewBag.Name = toy.Name;
            ViewBag.Type = toy.Type;
            ViewBag.Price = toy.Price;

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Toy toy)
        {
            if (toy == null) {
                return new BadRequestResult();
            }
            
            var newtoy = db.Toys.Find(toy.Id);
            newtoy.Name = toy.Name;
            newtoy.Type = toy.Type;
            newtoy.Price = toy.Price;
            db.SaveChanges();

            return Redirect("/Toy/Index");
        }
    }
}
