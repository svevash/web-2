using System;
using System.Linq;

namespace toyshop
{
    public class ShowManager
    {
        private ToyContainer _container;
        private BrandContainer _brand;
        private ColorContainer _color;
        private MaterialContainer _material;
        private TypeContainer _type;

        public ToyContainer Container
        {
            get => _container;
            set => _container = value;
        }

        public BrandContainer BrandContainer
        {
            get => _brand;
            set => _brand = value;
        }

        public ColorContainer ColorContainer
        {
            get => _color;
            set => _color = value;
        }

        public MaterialContainer MaterialContainer
        {
            get => _material;
            set => _material = value;
        }

        public TypeContainer TypeContainer
        {
            get => _type;
            set => _type = value;
        }

        public ShowManager()
        {
            _container = new ToyContainer();
            _brand = new BrandContainer();
            _color = new ColorContainer();
            _material = new MaterialContainer();
            _type = new TypeContainer();
        }

        public Toy FindToy(int id)
        {
            return _container.List.FirstOrDefault(t => t.Id == id);
        }

        public Brand FindBrand(int id)
        {
            return _brand.Brands.Keys.FirstOrDefault(t => t.Id == id);
        }

        public Color FindColor(int id)
        {
            return _color.Colors.Keys.FirstOrDefault(t => t.Id == id);
        }

        public Material FindMaterial(int id)
        {
            return _material.Materials.Keys.FirstOrDefault(t => t.Id == id);
        }

        public ToyType FindType(int id)
        {
            return _type.Types.Keys.FirstOrDefault(t => t.Id == id);
        }

        public void ShowAll()
        {
            Console.WriteLine("\nid, name | type | brand | color | materials | price");
            foreach (var i in _container.List)
            {
                Console.Write(i.Id + ", " + i.Name + " | " + FindType(i.IdType).Id + ", " + FindType(i.IdType).Name + 
                              " | " + FindBrand(i.IdBrand).Id + ", " + FindBrand(i.IdBrand).Name + " | " 
                              + FindColor(i.IdColor).Id + ", " + FindColor(i.IdColor).Name + " | ");
                foreach (var m in i.IdMaterial)
                {
                    Console.Write(FindMaterial(m).Id + ", " + FindMaterial(m).Name + "; ");
                }
                Console.Write("| " + i.Price + "\n");
            }
            Console.WriteLine();
        }

        public void ShowByBrand()
        {
            Console.WriteLine("brand id, brand name | toy id,..");
            foreach (var (key, value) in _brand.Brands)
            {
                Console.Write(key.Id + ", " + key.Name + " | ");
                foreach (var t in value)
                {
                    Console.Write(t + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        
        public void ShowByColor()
        {
            Console.WriteLine("color id, color name | toy id,..");
            foreach (var (key, value) in _color.Colors)
            {
                Console.Write(key.Id + ", " + key.Name + " | ");
                foreach (var t in value)
                {
                    Console.Write(t + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        
        public void ShowByMaterial()
        {
            Console.WriteLine("material id, material name | toy id,..");
            foreach (var (key, value) in _material.Materials)
            {
                Console.Write(key.Id + ", " + key.Name + " | ");
                foreach (var t in value)
                {
                    Console.Write(t + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        
        public void ShowByType()
        {
            Console.WriteLine("type id, type name | toy id,..");
            foreach (var (key, value) in _type.Types)
            {
                Console.Write(key.Id + ", " + key.Name + " | ");
                foreach (var t in value)
                {
                    Console.Write(t + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}