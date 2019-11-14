using System;
using System.Collections.Generic;
using System.Linq;

namespace toyshop
{
    public class StorageManager
    {
        // < toyname, quantity > 
        private Dictionary<string, int> _storage;

        public Dictionary<string, int> Storage
        {
            get => _storage;
            set => _storage = value;
        }

        public StorageManager()
        {
            _storage = new Dictionary<string, int>();
        }

        public bool Add(string name, int quantity)
        {
            if (_storage.ContainsKey(name))
            {
                _storage[name] += quantity;
                return true;
            }

            _storage.Add(name, quantity);
            Console.WriteLine(name + " added to storage. Current quantity is " + _storage[name]);
            return true;
        }

        public bool Remove(string name, int quantity)
        {
            if (!_storage.ContainsKey(name)) return false;
            
            if (_storage[name] < quantity)
            {
                return false;
            }

            if (_storage[name] == quantity)
            {
                _storage.Remove(name);
                Console.WriteLine(name + " removed from storage. Current quantity is " + _storage[name]);
                return true;
            }

            _storage[name] -= quantity;
            Console.WriteLine(name + " removed from storage. Current quantity is " + _storage[name]);            
            return true;
        }

        public HashSet<string> GetToysNames()
        {
            return _storage.Keys.ToHashSet();
        }

        public bool ContainsToy(string name)
        {
            return _storage.ContainsKey(name);
        }
        public int GetQuantity(string name)
        {
            if (!_storage.ContainsKey(name))
            {
                return -1;
            }

            return _storage[name];
        }
    }
}