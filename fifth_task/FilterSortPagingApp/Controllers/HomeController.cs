using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilterSortPagingApp.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace FilterSortPagingApp.Controllers
{
    public class HomeController : Controller
    {
        ToyContext db;
        public HomeController(ToyContext context)
        {
            db = context;
            // добавляем начальные данные
            if (db.ToyTypes.Count() != 0) return;
            var cat = new ToyType { Name = "cat" }; 
            var lego = new ToyType { Name = "lego" };
            var dog = new ToyType { Name = "dog" }; 
            var mouse = new ToyType { Name = "mouse" };
            var doll = new ToyType { Name = "doll" }; 

            var toy1 = new Toy { Name = "Grumpy Cat", Type = cat, Price = 599, CreationDate = DateTime.Now};
            var toy2 = new Toy { Name = "Tom The Cat", Type = cat, Price = 499, CreationDate = DateTime.Now };
            var toy3 = new Toy { Name = "Jerry The Mouse", Type = mouse, Price = 599, CreationDate = DateTime.Now };
            var toy4 = new Toy { Name = "Mickey Mouse", Type = mouse, Price = 1099, CreationDate = DateTime.Now };
            var toy5 = new Toy { Name = "Minnie Mouse", Type = mouse, Price = 399, CreationDate = DateTime.Now };
            var toy6 = new Toy { Name = "Barbie", Type = doll, Price = 299, CreationDate = DateTime.Now };
            var toy7 = new Toy { Name = "Ken", Type = doll, Price = 1199, CreationDate = DateTime.Now };
            var toy8 = new Toy { Name = "Blue Sad Dog", Type = dog, Price = 899, CreationDate = DateTime.Now };
            var toy9 = new Toy { Name = "Star Wars", Type = lego, Price = 199, CreationDate = DateTime.Now };
            var toy10 = new Toy { Name = "Ninjago", Type = lego, Price = 299, CreationDate = DateTime.Now};
                
            db.ToyTypes.AddRange(cat, dog, lego, mouse, doll);
            db.Toys.AddRange(toy1, toy2, toy3, toy4, toy5, toy6, toy7, toy8, toy9, toy10);
            db.SaveChanges();
        }
        public async Task<IActionResult> Index(int? type, string name, int page = 1,
            SortState sortOrder = SortState.NameAsc)
        {
            const int pageSize = 5;

            //фильтрация
            IQueryable<Toy> toys = db.Toys.Include(x => x.Type);

            if (type != null && type != 0)
            {
                toys = toys.Where(p => p.TypeId == type);
            }
            if (!string.IsNullOrEmpty(name))
            {
                toys = toys.Where(p => p.Name.Contains(name));
            }

            // сортировка
            toys = sortOrder switch
            {
                SortState.NameDesc => toys.OrderByDescending(s => s.Name),
                SortState.PriceAsc => toys.OrderBy(s => s.Price),
                SortState.PriceDesc => toys.OrderByDescending(s => s.Price),
                SortState.TypeAsc => toys.OrderBy(s => s.Type.Name),
                SortState.TypeDesc => toys.OrderByDescending(s => s.Type.Name),
                _ => toys.OrderBy(s => s.Name)
            };

            // пагинация
            var count = await toys.CountAsync();
            var items = await toys.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            var viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.ToyTypes.ToList(), type, name),
                Toys = items
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Toy toy)
        {
            if (db.Toys.Contains(toy))
            {
                return BadRequest();
            }
            
            if(!db.ToyTypes.Contains(toy.Type))
            {
                db.ToyTypes.Add(toy.Type);
            }
            
            toy.CreationDate = DateTime.Now;
            db.Toys.Add(toy);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}