using Library.Application.General;
using Library.DomainModel;

namespace Library.Application.Commands.EditBook
{
    public class EditBookCommand : ICommand
    {
        public string Id { get; set; }
        public string BookTitle { get; set; }

        public Author Author { get; set; }
        public Genre Genre { get; set; }

        public int Year { get; set; }

        public int Pages { get; set; }

        public string Publisher { get; set; }

        public string Isbn { get; set; }

        public string Ean { get; set; }
    }
}
