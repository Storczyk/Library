using Library.Application.Queries.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Queries.Order
{
    public class OrderDetailQuery
    {
        public Guid OrderDetailId { get; set; }

        public DateTime ReturnDate { get; set; }

        public Guid OrderId { get; set; }

        public BookShortQuery Book { get; set; }
    }
}
