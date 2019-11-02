using System;
using System.Collections.Generic;

namespace toyshop
{
    public class Toy
    {
        private int _id;
        private string _name;
        private ToyType _type;
        private List<Material> _material;
        private Color _color;
        private Brand _brand;
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

        public ToyType Type
        {
            get => _type;
            set => _type = value;
        }

        public List<Material> Material
        {
            get => _material;
            set => _material = value;
        }

        public Color Color
        {
            get => _color;
            set => _color = value;
        }

        public Brand Brand
        {
            get => _brand;
            set => _brand = value;
        }

        public int Price
        {
            get => _price;
            set => _price = value;
        }


        public Toy(int id, string name, ToyType type, List<Material> material, Color color, Brand brand, int price)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));

            _id = id;
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _type = type ?? throw new ArgumentNullException(nameof(type));
            _material = material ?? throw new ArgumentNullException(nameof(material));
            _color = color ?? throw new ArgumentNullException(nameof(color));
            _brand = brand ?? throw new ArgumentNullException(nameof(brand));
            _price = price;
        }
    }
}