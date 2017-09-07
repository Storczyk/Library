using Library.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Application.Queries
{
    public class PaginatedList<T> : List<T>
    {
        public PaginationInfo PaginationInfo { get; set; }
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize, string bookTitle = null, Genre? genre = null, string userId = null)
        {
            PaginationInfo = new PaginationInfo();
            PaginationInfo.PageIndex = pageIndex;
            PaginationInfo.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PaginationInfo.BookTitle = bookTitle;
            PaginationInfo.Genre = genre;
            PaginationInfo.UserId = userId;
            this.AddRange(items);
        }

        public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize, string bookTitle = null, Genre? genre = null, string userId = null)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize, bookTitle, genre, userId);
        }
    }

    public class PaginationInfo
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage { get { return PageIndex > 1; } }
        public bool HasNextPage { get { return PageIndex < TotalPages; } }
        public string BookTitle { get; set; }
        public Genre? Genre { get; set; }
        public string UserId { get; set; }
    }

}
