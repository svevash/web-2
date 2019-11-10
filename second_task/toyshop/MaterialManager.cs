using System.Collections.Generic;
using System.Linq;

namespace toyshop
{
    public class MaterialManager
    {
        private static HashSet<Material> _materials;

        public HashSet<Material> Materials
        {
            get => _materials;
            set => _materials = value;
        }

        public MaterialManager()
        {
            _materials = new HashSet<Material>();
        }

        public void Add(string name)
        {
            if (_materials.Any(t => t.Name == name))
            {
                return;
            }

            _materials.Add(new Material(_materials.Count, name));
        }

        public static Material GetByName(string name)
        {
            return _materials.FirstOrDefault(t => t.Name == name);
        }

        public static Material GetById(int id)
        {
            return _materials.FirstOrDefault(t => t.Id == id);
        }
    }
}