using System;
using System.Collections.Generic;

namespace FirstApp
{
    public partial class ToyTypes
    {
        public ToyTypes()
        {
            Toys = new HashSet<Toys>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Toys> Toys { get; set; }
    }
}
