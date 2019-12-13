using System;
using System.Collections.Generic;
using System.Linq;

namespace toyshop
{
    public class CashierManager
    {
        private StorageManager _storageManager;
        private ToyManager _toyManager;

        // < toyname, price >
        private Dictionary<string, int> _prices;

        public Dictionary<string, int> Prices
        {
            get => _prices;
            set => _prices = value;
        }

        public CashierManager(StorageManager storageManager, ToyManager toyManager)
        {
            _prices = new Dictionary<string, int>();
            _storageManager = storageManager;
            _toyManager = toyManager;
        }
        
        public bool ChangePrice(string name, int price)
        {
            if (_prices.ContainsKey(name))
            {
                _prices[name] = price;
                return true;
            }

            if (!_storageManager.ContainsToy(name)) return false;
            _prices.Add(name, price);
            return true;
        }

        public bool OfferSale(string name, int sale)
        {
            if (!_prices.ContainsKey(name)) return false;

            if (sale <= 0 || sale > 100)
            {
                Console.WriteLine("The sale is too big!");
                return false;
            }
            _prices[name] -= _prices[name] % sale;
            return true;
        }

        public int GetQuantity(string name)
        {
            return _storageManager.GetQuantity(name);
        }

        public int GetPrice(string name)
        {
            return _prices.ContainsKey(name) ? _prices[name] : 0;
        }

        public int Sell(string name, int quantity, int money)
        {
            if (GetQuantity(name) < quantity)
            {
                Console.WriteLine("Not enough " + name + "(s) in storage");
                return money;
            }

            if (!_prices.ContainsKey(name))
            {
                Console.WriteLine(name + " does not have a price yet");
                return money;
            }

            int cost = quantity * GetPrice(name);

            if (cost > money)
            {
                Console.WriteLine("Not enough money to buy " + quantity + " " + name + "(s)");
                return money;
            }

            _storageManager.Remove(name, quantity);
            return money - cost;
        }

        public HashSet<int> GetBrands()
        {
            var result = new HashSet<int>();
            foreach (var (key, value) in _prices)
            {
                if (!_storageManager.ContainsToy(key)) continue;
                var toy = _toyManager.GetByName(key);
                result.Add(toy.IdBrand);
            }

            return result;
        }

        public HashSet<int> GetColors()
        {
            var result = new HashSet<int>();
            foreach (var t in _prices)
            {
                if (!_storageManager.ContainsToy(t.Key)) continue;
                var toy = _toyManager.GetByName(t.Key);
                result.Add(toy.IdColor);
            }

            return result;        
        }

        public HashSet<int> GetMaterials()
        {
            var result = new HashSet<int>();
            foreach (var (key, value) in _prices)
            {
                if (!_storageManager.ContainsToy(key)) continue;
                var toy = _toyManager.GetByName(key);
                result.Add(toy.IdMaterial);
            }

            return result;        
        }

        public HashSet<string> GetToys()
        {
            var result = new HashSet<string>();
            foreach (var t in _prices.Where(t => _storageManager.ContainsToy(t.Key)))
            {
                result.Add(t.Key);
            }

            return result;
        }
    }
}