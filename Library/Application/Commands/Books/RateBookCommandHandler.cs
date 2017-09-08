using Library.Application.General;
using Library.Infrastructure.Data;
using System.Threading.Tasks;

namespace Library.Application.Commands.Books
{
    public class RateBookCommandHandler : ICommandHandler<RateBookCommand>
    {
        private readonly IBookRepository bookRepository;

        public RateBookCommandHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public CommandResult Handle(RateBookCommand command)
        {
            var result = bookRepository.AddRating(command.BookId, command.Rating, command.User);

            return new CommandResult { Result = result ? "Book succesfully rated" : "You shall not pass" };
        }
    }
}
