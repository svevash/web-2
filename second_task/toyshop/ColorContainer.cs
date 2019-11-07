using System.Collections.Generic;

namespace toyshop
{
    public class ColorContainer
    {
        private Dictionary<Color, List<int>> _colors;

        public Dictionary<Color, List<int>> Colors
        {
            get => _colors;
            set => _colors = value;
        }

        public ColorContainer()
        {
            _colors = new Dictionary<Color, List<int>>();
        }
    }
}