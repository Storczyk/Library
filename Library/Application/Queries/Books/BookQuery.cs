﻿using Library.DomainModel;
using System.ComponentModel;

namespace Library.Application.Queries.Books
{
    public class BookQuery
    {
        public string Id { get; set; }

        [DisplayName("Title")]
        public string BookTitle { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public int Year { get; set; }

        public int Pages { get; set; }

        public string Publisher { get; set; }

        [DisplayName("ISBN")]
        public string Isbn { get; set; }

        [DisplayName("EAN")]
        public string Ean { get; set; }
    }
}
