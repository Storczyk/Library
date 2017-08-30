using Library.Application.General;

namespace Library.Application.Commands.EditBook
{
    public class EditBookCommand : ICommand
    {
        public string Id { get; set; }
        public string BookTitle { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public int Pages { get; set; }

        public string Publisher { get; set; }

        public string Isbn { get; set; }

        public string Ean { get; set; }
    }
}
