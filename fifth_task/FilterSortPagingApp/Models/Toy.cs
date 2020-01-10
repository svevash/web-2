using System;

namespace FilterSortPagingApp.Models
{
    public class Toy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime CreationDate { get; set; }
        public TimeSpan Lifetime => DateTime.Now - CreationDate;
        public int TypeId { get; set; }
        public ToyType Type { get; set; }

    }
}