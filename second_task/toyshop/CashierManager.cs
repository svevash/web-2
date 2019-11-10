using System.Collections.Generic;

namespace toyshop
{
    public class CashierManager
    {
        // < toyid, price >
        private Dictionary<int, int> _prices;

        public Dictionary<int, int> Prices
        {
            get => _prices;
            set => _prices = value;
        }

        public CashierManager()
        {
            _prices = new Dictionary<int, int>();
        }
        
        public bool ChangePrice(int id, int price)
        {
            if (_prices.ContainsKey(id))
            {
                _prices[id] = price;
                return true;
            }

            if (!StorageManager.ContainsToy(id)) return false;
            _prices.Add(id, price);
            return true;
        }
    }
}