using Library.DomainModel;
using Library.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Library.Application.Queries.Books
{
    public class BookShortQuery
    {
        [DisplayName("Title")]
        public string BookTitle { get; set; }

        public string Description { get; set; }

        public Author Author { get; set; }

        public Genre Genre { get; set; }
    }
}
