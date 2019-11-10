using System.Collections.Generic;
using System.Linq;

namespace toyshop
{
    public class BrandManager
    {
        private static HashSet<Brand> _brands;

        public HashSet<Brand> Brands
        {
            get => _brands;
            set => _brands = value;
        }

        public BrandManager()
        {
            _brands = new HashSet<Brand>();
        }

        public void Add(string name)
        {
            if (_brands.Any(t => t.Name == name))
            {
                return;
            }

            _brands.Add(new Brand(_brands.Count, name));
        }

        public static Brand GetByName(string name)
        {
            return _brands.FirstOrDefault(t => t.Name == name);
        }

        public static Brand GetById(int id)
        {
            return _brands.FirstOrDefault(t => t.Id == id);
        }
    }
}