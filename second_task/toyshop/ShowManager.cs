using System;

namespace toyshop
{
    public class ShowManager
    {
        private readonly ToyManager _toyManager;
        
        public ShowManager(ToyManager toyManager)
        {
            _toyManager = toyManager ?? throw new ArgumentNullException(nameof(toyManager));
        }

        public void ShowAll()
        {
            Console.WriteLine("id, name | type | brand | color | materials | price\n");
            foreach (var i in _toyManager.List)
            {
                Console.Write(i.Id + ", " + i.Name + " | " + i.Type.Id + ", " + i.Type.Name + " | " + 
                              i.Brand.Id + ", " + i.Brand.Name + " | " + i.Color.Id + ", " + i.Color.Name + " | ");
                foreach (var m in i.Material)
                {
                    Console.Write(m.Id + ", " + m.Name + "; ");
                }
                Console.Write("| " + i.Price + "\n");
            }
        }

        public Material GetMaterial(int id)
        {
            foreach (var i in _toyManager.Materials.Keys)
            {
                if (i.Id == id)
                {
                    return i;
                }
            }
        }
    }
}