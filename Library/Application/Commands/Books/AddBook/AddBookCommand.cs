using Library.Application.General;
using Library.DomainModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.Commands.Books.AddBook
{
    public class AddBookCommand : ICommand
    {
        [Required]
        [DisplayName("Title")]
        public string BookTitle { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Pages { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public string Publisher { get; set; }

        [DisplayName("ISBN")]
        public string Isbn { get; set; }

        [DisplayName("EAN")]
        public string Ean { get; set; }
    }
}
