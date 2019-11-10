using System.Collections.Generic;
using System.Linq;

namespace toyshop
{
    public class ToyManager
    {
        private static HashSet<Toy> _toys;

        public HashSet<Toy> Toys
        {
            get => _toys;
            set => _toys = value;
        }

        public ToyManager()
        {
            _toys = new HashSet<Toy>();
        }

        public void Add(string name, string material, string color, string brand)
        {
            if (_toys.Any(t => t.Name == name))
            {
                return;
            }

            _toys.Add(new Toy(_toys.Count, name, MaterialManager.GetByName(material).Id, 
                ColorManager.GetByName(color).Id, BrandManager.GetByName(brand).Id));
        }

        public Toy GetByName(string name)
        {
            return _toys.FirstOrDefault(t => t.Name == name);
        }

        public static Toy GetById(int id)
        {
            return _toys.FirstOrDefault(t => t.Id == id);
        }

        public Brand GetBrand(int id)
        {
            return _toys.Where(t => t.Id == id).Select(t => BrandManager.GetById(t.IdBrand)).FirstOrDefault();
        }

        public Color GetColor(int id)
        {
            return _toys.Where(t => t.Id == id).Select(t => ColorManager.GetById(t.IdColor)).FirstOrDefault();
        }

        public Material GetMaterial(int id)
        {
            return _toys.Where(t => t.Id == id).Select(t => MaterialManager.GetById(t.IdMaterial)).FirstOrDefault();
        }
    }
}