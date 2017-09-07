﻿using Library.DomainModel;
using Library.DomainModel.Enums;
using System.ComponentModel;

namespace Library.Application.Queries.Books
{
    public class BookShortQuery
    {
        public string Id { get; set; }

        [DisplayName("Title")]
        public string BookTitle { get; set; }

        public string Description { get; set; }

        public Author Author { get; set; }

        public Genre Genre { get; set; }
    }
}
