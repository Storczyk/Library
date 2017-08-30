using Library.Application.General;
using Library.DomainModel;
using System.ComponentModel;

namespace Library.Application.Commands.AddBook
{
    public class AddBookCommand : ICommand
    {
        [DisplayName("Title")]
        public string BookTitle { get; set; }

        public Author Author { get; set; }
        public Genre Genre { get; set; }

        public int Year { get; set; }

        public int Pages { get; set; }

        public string Publisher { get; set; }

        [DisplayName("ISBN")]
        public string Isbn { get; set; }

        [DisplayName("EAN")]
        public string Ean { get; set; }
    }
}
