using System;
using System.Collections.Generic;
using System.Linq;

namespace toyshop
{
    public class BrandManager
    {
        private HashSet<Brand> _brands;

        public HashSet<Brand> Brands
        {
            get => _brands;
            set => _brands = value;
        }

        public BrandManager()
        {
            _brands = new HashSet<Brand>();
        }

        public int Add(string name)
        {
            int id;
            if (_brands.Any(t => t.Name == name))
            {
                id = _brands.FirstOrDefault(t => t.Name == name).Id;
                Console.WriteLine(name + " already exists. Id is " + id);
                return id;
            }

            id = _brands.Count;
            _brands.Add(new Brand(id, name));
            Console.WriteLine(name + " added. Id is " + id);
            return id;
        }

        public Brand GetByName(string name)
        {
            return _brands.FirstOrDefault(t => t.Name == name);
        }

        public Brand GetById(int id)
        {
            return _brands.FirstOrDefault(t => t.Id == id);
        }
    }
}