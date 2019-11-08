using System;
using System.Collections.Generic;
using System.Linq;

namespace toyshop
{
    public class ToyManager
    {
        private ShowManager _showManager;

        public ShowManager ShowManage
        {
            get => _showManager;
            set => _showManager = value;
        }

        public ToyManager()
        {
            _showManager = new ShowManager();
        }

        public void AddToy(int id, string name, string type, string[] material, string brand, string color, int price)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (material == null) throw new ArgumentNullException(nameof(material));
            if (brand == null) throw new ArgumentNullException(nameof(brand));
            if (color == null) throw new ArgumentNullException(nameof(color));
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
            if (price <= 0) throw new ArgumentOutOfRangeException(nameof(price));
            if (_showManager.Container.List.Any(t => t.Id == id))
                throw new Exception("toy id already exists");
            if (material.Length == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(material));

            int typeid = -1;
            foreach (var t in _showManager.TypeContainer.Types.Where(t => t.Key.Name == type))
            {
                typeid = t.Key.Id;
                break;
            }

            if (typeid == -1)
            {
                typeid = _showManager.TypeContainer.Types.Count;
                _showManager.TypeContainer.Types.Add(new ToyType(typeid, type), new List<int>());
            }

            int brandid = -1;
            foreach (var t in _showManager.BrandContainer.Brands.Where(t => t.Key.Name == brand))
            {
                brandid = t.Key.Id;
                break;
            }

            if (brandid == -1)
            {
                brandid = _showManager.BrandContainer.Brands.Count;
                _showManager.BrandContainer.Brands.Add(new Brand(brandid, brand), new List<int>());
            }

            int colorid = -1;
            foreach (var t in _showManager.ColorContainer.Colors.Where(t => t.Key.Name == color))
            {
                colorid = t.Key.Id;
                break;
            }

            if (colorid == -1)
            {
                colorid = _showManager.ColorContainer.Colors.Count;
                _showManager.ColorContainer.Colors.Add(new Color(colorid, type), new List<int>());
            }

            List<int> materialid = new List<int>();
            for (int i = 0; i < material.Length; i++)
            {
                materialid.Add(-1);
                foreach (var t in _showManager.MaterialContainer.Materials.Where(t => t.Key.Name == material[i]))
                {
                    materialid[i] = t.Key.Id;
                    break;
                }

                if (materialid[i] == -1)
                {
                    materialid[i] = _showManager.MaterialContainer.Materials.Count;
                    _showManager.MaterialContainer.Materials.Add(new Material(materialid[i], material[i]),
                        new List<int>());
                }
            }

            Toy toy = new Toy(id, name, typeid, materialid, colorid, brandid, price);

            _showManager.Container.List.Add(toy);

            foreach (var t in toy.IdMaterial)
            {
                _showManager.MaterialContainer.Materials[_showManager.FindMaterial(t)].Add(toy.Id);
            }

            _showManager.BrandContainer.Brands[_showManager.FindBrand(toy.IdBrand)].Add(toy.Id);
            
            _showManager.ColorContainer.Colors[_showManager.FindColor(toy.IdColor)].Add(toy.Id);
            
            _showManager.TypeContainer.Types[_showManager.FindType(toy.IdType)].Add(toy.Id);
        }
    }
}