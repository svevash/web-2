using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FilterSortPagingApp.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(IList<ToyType> types, int? type, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            types.Insert(0, new ToyType { Name = "All", Id = 0 });
            Types = new SelectList(types, "Id", "Name", type);
            SelectedType = type;
            SelectedName = name;
        }
        public SelectList Types { get; } // список компаний
        public int? SelectedType { get; }   // выбранная компания
        public string SelectedName { get; }    // введенное имя
    }
}