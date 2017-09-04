using Library.Application.Queries.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Application.Queries.Order
{
    public class OrderQuery
    {
        public IEnumerable<BookQuery> Books { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int PhoneNumber { get; set; }
    }
}
