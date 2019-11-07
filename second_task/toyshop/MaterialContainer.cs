using System.Collections.Generic;

namespace toyshop
{
    public class MaterialContainer
    {
        private Dictionary<Material, List<int>> _materials;

        public Dictionary<Material, List<int>> Materials
        {
            get => _materials;
            set => _materials = value;
        }

        public MaterialContainer()
        {
            _materials = new Dictionary<Material, List<int>>();
        }
    }
}