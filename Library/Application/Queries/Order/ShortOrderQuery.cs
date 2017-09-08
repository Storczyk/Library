using Library.Application.Queries.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.Queries.Order
{
    public class ShortOrderQuery
    {
        [DisplayName("Books")]
        public IEnumerable<BookRatingQuery> Books { get; set; }

        [Required]
        public string Address { get; set; }

        [Required, Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
    }
}
