using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fourth.Models
{
    public class ToyType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Toy> Toys { get; set; }
    }
}
