using System.Collections.Generic;

namespace toyshop
{
    public class ToyContainer
    {
        private List<Toy> _list;

        public List<Toy> List
        {
            get => _list;
            set => _list = value;
        }

        public ToyContainer()
        {
            _list = new List<Toy>();
        }
    }
}