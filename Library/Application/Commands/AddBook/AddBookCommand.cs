using Library.Application.General;
using System.ComponentModel;

namespace Library.Application.Commands.AddBook
{
    public class AddBookCommand : ICommand
    {
        [DisplayName("Title")]
        public string BookTitle { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public int Pages { get; set; }

        public string Publisher { get; set; }

        [DisplayName("ISBN")]
        public string Isbn { get; set; }

        [DisplayName("EAN")]
        public string Ean { get; set; }
    }
}
