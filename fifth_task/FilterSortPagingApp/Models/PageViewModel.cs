﻿using System;

namespace FilterSortPagingApp.Models
{
    public class PageViewModel
    {
        public int PageNumber { get; }
        private int TotalPages { get; }

        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPreviousPage => (PageNumber > 1);

        public bool HasNextPage => (PageNumber < TotalPages);
    }
}