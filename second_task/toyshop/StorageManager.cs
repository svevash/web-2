using System;
using System.Collections.Generic;
using System.Linq;

namespace toyshop
{
    public class StorageManager
    {
        // < toyid, quantity > 
        private static Dictionary<int, int> _storage;

        public Dictionary<int, int> Storage
        {
            get => _storage;
            set => _storage = value;
        }

        public StorageManager()
        {
            _storage = new Dictionary<int, int>();
        }

        public bool Add(int id, int quantity)
        {
            if (_storage.ContainsKey(id))
            {
                _storage[id] += quantity;
                return true;
            }

            if (ToyManager.GetById(id) == null) return false;
            _storage.Add(id, quantity);
            return true;

            //Console.WriteLine("such toy doesn't exist!");
        }

        public bool Remove(int id, int quantity)
        {
            if (!_storage.ContainsKey(id)) return false;
            
            if (_storage[id] < quantity)
            {
                //Console.WriteLine("you are trying to remove more toys than the storage contains!");
                return false;
            }

            if (_storage[id] == quantity)
            {
                _storage.Remove(id);
                return true;
            }

            _storage[id] -= quantity;
            return true;

            //Console.WriteLine("such toy doesn't exist!");
        }

        public List<int> GetToysId()
        {
            return _storage.Select(t => t.Key).ToList();
        }

        public static bool ContainsToy(int id)
        {
            return _storage.ContainsKey(id);
        }
    }
}