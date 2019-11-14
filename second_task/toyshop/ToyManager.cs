using System;
using System.Collections.Generic;
using System.Linq;

namespace toyshop
{
    public class ToyManager
    {
        private HashSet<Toy> _toys;

        public HashSet<Toy> Toys
        {
            get => _toys;
            set => _toys = value;
        }

        public ToyManager()
        {
            _toys = new HashSet<Toy>();
        }

        public void Add(string name, int materialId, int colorId, int brandId)
        {
            if (_toys.Any(t => t.Name == name))
            {
                Console.WriteLine("Toy with such name already exists!");
                return;
            }
            Console.WriteLine("Success!");
            _toys.Add(new Toy(name, materialId, colorId, brandId));
        }

        public Toy GetByName(string name)
        {
            if (_toys.All(t => t.Name != name))
            {
                throw new System.ArgumentOutOfRangeException("Toy with name" + name + "Does not exist");
            }

            return _toys.FirstOrDefault(t => t.Name == name);
        }

        public HashSet<int> GetBrands()
        {
            return _toys.Select(t => t.IdBrand).ToHashSet();
        }

        public HashSet<string> GetByBrandId(int brandId)
        {
            return _toys.Where(t => t.IdBrand == brandId).Select(t => t.Name).ToHashSet();
        }

        public HashSet<int> GetColors()
        {
            return _toys.Select(t => t.IdColor).ToHashSet();
        }

        public HashSet<string> GetByColorId(int colorId)
        {
            return _toys.Where(t => t.IdColor == colorId).Select(t => t.Name).ToHashSet();
        }

        public HashSet<int> GetMaterials()
        {
            return _toys.Select(t => t.IdMaterial).ToHashSet();
        }

        public HashSet<string> GetByMaterialId(int materialId)
        {
            return _toys.Where(t => t.IdMaterial == materialId).Select(t => t.Name).ToHashSet();
        }
        
        public void ShowToys(HashSet<string> toys)
        {
            Console.WriteLine("\nToys:");
            foreach (var t in toys)
            {
                Console.WriteLine("name: " + t + " id brand: " + GetByName(t).IdBrand + " id color: " + GetByName(t).IdColor
                                  + " id material: " + GetByName(t).IdMaterial);
            }
            Console.WriteLine();
        }

        public void ShowByBrand(int id, HashSet<string> toys)
        {
            Console.WriteLine("\nToys:");
            foreach (var t in toys.Where(t => GetByName(t).IdBrand == id))
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();
        }
        
        public void ShowByColor(int id, HashSet<string> toys)
        {
            Console.WriteLine("\nToys:");
            foreach (var t in toys.Where(t => GetByName(t).IdColor == id))
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();
        }
        
        public void ShowByMaterial(int id, HashSet<string> toys)
        {
            Console.WriteLine("\nToys:");
            foreach (var t in toys.Where(t => GetByName(t).IdMaterial == id))
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();
        }
    }
}