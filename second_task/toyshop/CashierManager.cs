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

            if (_storageManager.ContainsToy(name)) return false;
            _prices.Add(name, price);
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
                Console.WriteLine("Not enouh " + name +"(s) in storage");
                return money;
            }

            if (!_prices.ContainsKey(name))
            {
                Console.WriteLine(name + " does not have a price yet");
                return money;
            }

            int cost = quantity * GetPrice(name);

            if (cost < money)
            {
                Console.WriteLine("Not enough money to buy " + quantity + " " + name + "(s)");
                return money;
            }

            _storageManager.Remove(name, quantity);
            return money - cost;
        }

        public HashSet<int> GetBrands()
        {
            return (from t in _prices.Keys where _storageManager.ContainsToy(t) select _toyManager.GetByName(t).IdBrand).ToHashSet();
        }

        public HashSet<int> GetColors()
        {
            return (from t in _prices.Keys where _storageManager.ContainsToy(t) select _toyManager.GetByName(t).IdColor).ToHashSet();
        }

        public HashSet<int> GetMaterials()
        {
            return (from t in _prices.Keys where _storageManager.ContainsToy(t) select _toyManager.GetByName(t).IdMaterial).ToHashSet();
        }      
    }
}