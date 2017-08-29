using Library.Application.General;

namespace Library.Application.Commands.AddBook
{
    public class AddBookCommand : ICommand
    {
        public string BookTitle { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public int Pages { get; set; }

        public string Publisher { get; set; }

        public long Isbn { get; set; }

        public long Ean { get; set; }
    }
}
