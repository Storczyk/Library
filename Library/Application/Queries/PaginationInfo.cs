using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Queries
{
    public abstract class PaginationInfo
    {
        public int Page { get; set; }
        public int HowManyPages { get; set; }
        public int PageSize { get; set; }
    }
}
