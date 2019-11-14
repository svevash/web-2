using System;
using System.Collections.Generic;
using System.Linq;

namespace toyshop
{
    public class MaterialManager
    {
        private HashSet<Material> _materials;

        public HashSet<Material> Materials
        {
            get => _materials;
            set => _materials = value;
        }

        public MaterialManager()
        {
            _materials = new HashSet<Material>();
        }

        public int Add(string name)
        {
            int id;
            if (_materials.Any(t => t.Name == name))
            {
                id = _materials.FirstOrDefault(t => t.Name == name).Id;
                Console.WriteLine(name + " already exists. Id is " + id);
                return id;
            }

            id = _materials.Count;
            _materials.Add(new Material(id, name));
            Console.WriteLine(name + " added. Id is " + id);
            return id;
        }

        public Material GetByName(string name) => _materials.FirstOrDefault(t => t.Name == name);

        public Material GetById(int id) => _materials.FirstOrDefault(t => t.Id == id);
        
        public void ShowMaterials(HashSet<int> idmaterials)
        {
            Console.WriteLine("\nMaterials:");
            foreach (var t in idmaterials)
            {
                Console.WriteLine("id: " + t + " name: " + GetById(t).Name);
            }
            Console.WriteLine();
        }
    }
}