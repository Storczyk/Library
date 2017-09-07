using Library.Application.General;
using Library.DomainModel.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace Library.Application.Commands.Books
{
    public class EditBookCommand : ICommand
    {
        public string Id { get; set; }

        [DisplayName("Title")]
        public string BookTitle { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public Genre Genre { get; set; }

        public int Year { get; set; }

        public int Pages { get; set; }

        public string Publisher { get; set; }

        public string Isbn { get; set; }

        public string Ean { get; set; }

        public int Quantity { get; set; }

        public IFormFile Image { get; set; }
    }
}
