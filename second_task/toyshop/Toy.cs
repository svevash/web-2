using System;
using System.Collections.Generic;

namespace toyshop
{
    public class Toy
    {
        private int _id;
        private string _name;
        private int _idType;
        private List<int> _idMaterial;
        private int _idColor;
        private int _idBrand;
        private int _price;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int IdType
        {
            get => _idType;
            set => _idType = value;
        }

        public List<int> IdMaterial
        {
            get => _idMaterial;
            set => _idMaterial = value;
        }

        public int IdColor
        {
            get => _idColor;
            set => _idColor = value;
        }

        public int IdBrand
        {
            get => _idBrand;
            set => _idBrand = value;
        }

        public int Price
        {
            get => _price;
            set => _price = value;
        }
        
        public Toy(int id, string name, int type, List<int> material, int color, int brand, int price)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            if (type < 0) throw new ArgumentOutOfRangeException(nameof(type));
            if (color < 0) throw new ArgumentOutOfRangeException(nameof(color));
            if (brand < 0) throw new ArgumentOutOfRangeException(nameof(brand));
            if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));
            
            _id = id;
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _idType = type;
            _idMaterial = material ?? throw new ArgumentNullException(nameof(material));
            _idColor = color;
            _idBrand = brand;
            _price = price;
        }
    }
}