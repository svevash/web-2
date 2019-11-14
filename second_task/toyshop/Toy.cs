using System;
using System.Collections.Generic;

namespace toyshop
{
    public class Toy
    {
        private string _name;
        private int _idMaterial;
        private int _idColor;
        private int _idBrand;

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        
        public int IdMaterial
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
        
        public Toy(string name, int material, int color, int brand)
        {
            if (name.Length == 0) throw new ArgumentOutOfRangeException(nameof(name));
            if (color < 0) throw new ArgumentOutOfRangeException(nameof(color));
            if (brand < 0) throw new ArgumentOutOfRangeException(nameof(brand));
            if (material < 0) throw new ArgumentOutOfRangeException(nameof(material));

            _name = name;
            _idMaterial = material;
            _idColor = color;
            _idBrand = brand;
        }
    }
}