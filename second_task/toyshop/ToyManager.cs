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
                return;
            }

            _toys.Add(new Toy(name, materialId, colorId, brandId));
        }

        public Toy GetByName(string name)
        {
            if (_toys.All(t => t.Name != name))
            {
                throw new System.ArgumentOutOfRangeException("Toy with name" + name + "Doex not exist");
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
    }
}