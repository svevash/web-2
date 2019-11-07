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
        
        
//        private readonly ToyManager _toyManager;
//        
//        public ShowManager(ToyManager toyManager)
//        {
//            _toyManager = toyManager ?? throw new ArgumentNullException(nameof(toyManager));
//        }
//
//        public void ShowAll()
//        {
//            Console.WriteLine("id, name | type | brand | color | materials | price\n");
//            foreach (var i in _toyManager.List)
//            {
//                Console.Write(i.Id + ", " + i.Name + " | " + i.Type.Id + ", " + i.Type.Name + " | " + 
//                              i.Brand.Id + ", " + i.Brand.Name + " | " + i.Color.Id + ", " + i.Color.Name + " | ");
//                foreach (var m in i.Material)
//                {
//                    Console.Write(m.Id + ", " + m.Name + "; ");
//                }
//                Console.Write("| " + i.Price + "\n");
//            }
//        }
//
//        public Material GetMaterial(int id)
//        {
//            foreach (var i in _toyManager.Materials.Keys)
//            {
//                if (i.Id == id)
//                {
//                    return i;
//                }
//            }
//        }
    }
}