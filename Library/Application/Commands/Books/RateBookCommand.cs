using Library.Application.General;
using System.Security.Claims;

namespace Library.Application.Commands.Books
{
    public class RateBookCommand : ICommand
    {
        public ClaimsPrincipal User { get; set; }

        public int Rating { get; set; }

        public string BookId { get; set; }
    }
}
