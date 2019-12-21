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
    public class TypeController : Controller
    {
        readonly ShopContext db;
        public TypeController(ShopContext context)
        {
            db = context;
        }
        
        public IActionResult Index(string text)
        {
            if (text == null || text.Trim() == "") return View(db.Types.ToList());
            var types = db.Types.Where(c => c.Name.Contains(text));

            return View(types);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ToyType type)
        {
            db.Types.Add(type);
            db.SaveChanges();
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) {
                return new BadRequestResult();
            }
            
            var type = db.Types.Find(id);
            if (type == null) {
                return new NotFoundResult();
            }
            db.Types.Remove(db.Types.Find(id));
            
            for (var i = 0; i < db.Types.ToArray().Length; i++)
            {
                db.Types.ToArray()[i].Id = i + 1;
            }
            
            db.SaveChanges();
            return Redirect("/Type/Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) {
                return new BadRequestResult();
            }
            
            var type = db.Types.Find(id);
            if (type == null) {
                return new NotFoundResult();
            }
            
            ViewBag.Id = type.Id;
            ViewBag.Name = type.Name;
            
            return View();
        }

        [HttpPost]
        public IActionResult Edit(ToyType type)
        {
            if (type == null) {
                return new BadRequestResult();
            }

            var newtype = db.Types.Find(type.Id);
            newtype.Name = type.Name;
            db.SaveChanges();

            return Redirect("/Type/Index");
        }
    }
}
