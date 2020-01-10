using System;
using System.Collections.Generic;

namespace FirstApp
{
    public partial class Toys
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime CreationDate { get; set; }
        public int TypeId { get; set; }

        public virtual ToyTypes Type { get; set; }
    }
}
