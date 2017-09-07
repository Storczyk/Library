using Library.Application.General;
using Library.Infrastructure.Data;

namespace Library.Application.Commands.Order
{
    public class ReturnBookCommandHandler : ICommandHandler<ReturnBookCommand>
    {
        private readonly IOrderRepository orderRepository;
        public ReturnBookCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public CommandResult Handle(ReturnBookCommand createOrderCommand)
        {
            var result = orderRepository.BookReturment(createOrderCommand.OrderDetailId);
            return new CommandResult
            {
                Result = result ? "Book Returned" : "Book not returned"
            };
        }
    }
}
