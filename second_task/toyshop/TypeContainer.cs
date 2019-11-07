using System.Collections.Generic;

namespace toyshop
{
    public class TypeContainer
    {
        private Dictionary<ToyType, List<int>> _types;
        
        public Dictionary<ToyType, List<int>> Types
        {
            get => _types;
            set => _types = value;
        }

        public TypeContainer()
        {
            _types = new Dictionary<ToyType, List<int>>();
        }
    }
}