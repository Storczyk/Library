using Library.Application.General;
using Library.Infrastructure.Data;

namespace Library.Application.Commands.Order
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly IBookRepository repository;

        public CreateOrderCommandHandler(IBookRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(CreateOrderCommand command)
        {
            //repository.
        }
    }
}
