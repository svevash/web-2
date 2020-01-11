using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fourth.Models
{
    public class Toy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public virtual ToyType Type { get; set; }
    }
}
