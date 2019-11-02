using System;

namespace toyshop
{
    public class Color
    {
        private int _id;
        private string _name;

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

        public Color(int id, string name)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            _id = id;
            _name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}