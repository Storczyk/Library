using Library.Application.General;
using System.ComponentModel;

namespace Library.Application.Commands.Books.EditBook
{
    public class EditBookCommand : ICommand
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

        public string Isbn { get; set; }

        public string Ean { get; set; }
    }
}
