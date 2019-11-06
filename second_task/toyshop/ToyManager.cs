using System;
using System.Collections.Generic;
using System.Linq;

namespace toyshop
{
    public class ToyManager
    {
        private readonly List<Toy> _list;
        private Dictionary<ToyType, List<int>> _types;
        private Dictionary<Material, List<int>> _materials;
        private Dictionary<Color, List<int>> _colors;
        private Dictionary<Brand, List<int>> _brands;

        public List<Toy> List => _list;
        
        public Dictionary<ToyType, List<int>> Types
        {
            get => _types;
            set => _types = value;
        }

        public Dictionary<Material, List<int>> Materials
        {
            get => _materials;
            set => _materials = value;
        }

        public Dictionary<Color, List<int>> Colors
        {
            get => _colors;
            set => _colors = value;
        }

        public Dictionary<Brand, List<int>> Brands
        {
            get => _brands;
            set => _brands = value;
        }

        public ToyManager()
        {
            _list = new List<Toy>();
            _types = new Dictionary<ToyType, List<int>>();
            _materials = new Dictionary<Material, List<int>>();
            _colors = new Dictionary<Color, List<int>>();
            _brands = new Dictionary<Brand, List<int>>();
        }
        
        public void AddToy(Toy toy)
        {
            if (toy == null) throw new ArgumentNullException(nameof(toy));
            
            _list.Add(toy);
            
            foreach (var t in toy.Material)
            {
                if (!_materials.ContainsKey(t))
                    _materials.Add(t, new List<Toy>());
                _materials[t].Add(toy);
            }
            
            if (!_types.ContainsKey(toy.Type))
                _types.Add(toy.Type, new List<Toy>());
            _types[toy.Type].Add(toy);
            
            if (!_colors.ContainsKey(toy.Color))
                _colors.Add(toy.Color, new List<Toy>());
            _colors[toy.Color].Add(toy);
            
            if (!_brands.ContainsKey(toy.Brand))
                _brands.Add(toy.Brand, new List<Toy>());
            _brands[toy.Brand].Add(toy);
        }

        public void RemoveToy(Toy toy)
        {
            if (toy == null) throw new ArgumentNullException(nameof(toy));
            
            if (_list.Contains(toy))
                _list.Remove(toy);

            if (_types[toy.Type].Contains(toy))
                _types[toy.Type].Remove(toy);

            foreach (var t in toy.Material.Where(t => _materials[t].Contains(toy)))
            {
                _materials[t].Remove(toy);
            }
            
            if (_colors[toy.Color].Contains(toy))
                _colors[toy.Color].Remove(toy);

            if (_brands[toy.Brand].Contains(toy))
                _brands[toy.Brand].Remove(toy);
        }
        
    }
}