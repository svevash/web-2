using System.Collections.Generic;
using System.Linq;

namespace toyshop
{
    public class ColorManager
    {
        private static HashSet<Color> _colors;

        public HashSet<Color> Colors
        {
            get => _colors;
            set => _colors = value;
        }

        public ColorManager()
        {
            _colors = new HashSet<Color>();
        }

        public void Add(string name)
        {
            if (_colors.Any(t => t.Name == name))
            {
                return;
            }

            _colors.Add(new Color(_colors.Count, name));
        }

        public static Color GetByName(string name)
        {
            return _colors.FirstOrDefault(t => t.Name == name);
        }

        public static Color GetById(int id)
        {
            return _colors.FirstOrDefault(t => t.Id == id);
        }
    }
}