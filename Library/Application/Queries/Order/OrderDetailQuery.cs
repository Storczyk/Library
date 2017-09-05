using Library.Application.Queries.Books;
using System;
using System.ComponentModel;

namespace Library.Application.Queries.Order
{
    public class OrderDetailQuery
    {
        public Guid OrderDetailId { get; set; }

        [DisplayName("Date of returnment")]
        public DateTime ReturnDate { get; set; }

        [DisplayName("Order's ID")]
        public Guid OrderId { get; set; }

        public BookShortQuery Book { get; set; }
    }
}
