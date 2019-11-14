using System;
using System.Collections.Generic;
using System.Linq;

namespace toyshop
{
    public class ColorManager
    {
        private HashSet<Color> _colors;

        public HashSet<Color> Colors
        {
            get => _colors;
            set => _colors = value;
        }

        public ColorManager()
        {
            _colors = new HashSet<Color>();
        }

        public int Add(string name)
        {
            int id;
            if (_colors.Any(t => t.Name == name))
            {
                id = _colors.FirstOrDefault(t => t.Name == name).Id;
                Console.WriteLine(name + " already exists. Id is " + id);
                return id;
            }

            id = _colors.Count;
            _colors.Add(new Color(id, name));
            Console.WriteLine(name + " added. Id is " + id);
            return id;
        }

        public Color GetByName(string name) => _colors.FirstOrDefault(t => t.Name == name);

        public Color GetById(int id) => _colors.FirstOrDefault(t => t.Id == id);
        
        public void ShowColors(HashSet<int> idcolors)
        {
            Console.WriteLine("\nColors:");
            foreach (var t in idcolors)
            {
                Console.WriteLine("id: " + t + " name: " + GetById(t).Name);
            }
            Console.WriteLine();
        }
    }
}