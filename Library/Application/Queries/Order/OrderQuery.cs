using Library.Application.Queries.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Application.Queries.Order
{
    public class OrderQuery
    {
        [Display(Name = "Books")]
        public IEnumerable<BookShortQuery> Books { get; set; }

        [Required]
        public string Address { get; set; }

        [Required, Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
    }
}
