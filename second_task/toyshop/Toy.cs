using System;
using System.Collections.Generic;

namespace toyshop
{
    public class Toy
    {
        private int _id;
        private string _name;
        private int _idMaterial;
        private int _idColor;
        private int _idBrand;

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
        
        public Toy(int id, string name, int material, int color, int brand)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            if (color < 0) throw new ArgumentOutOfRangeException(nameof(color));
            if (brand < 0) throw new ArgumentOutOfRangeException(nameof(brand));
            if (material < 0) throw new ArgumentOutOfRangeException(nameof(material));

            _id = id;
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _idMaterial = material;
            _idColor = color;
            _idBrand = brand;
        }
    }
}