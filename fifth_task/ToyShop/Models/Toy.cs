using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToyShop.Models
{
    public class Toy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan LifeTime => DateTime.Now - CreationDate;
        public int TypeId { get; set; }
        public ToyType Type { get; set; }
        private DateTime CreationDate { get; set; }
    }
}