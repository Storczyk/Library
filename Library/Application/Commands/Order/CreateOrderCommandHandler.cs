using Library.Application.General;
using Library.DomainModel;
using Library.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Application.Commands.Order
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly IBookRepository bookRepository;
        private readonly IOrderRepository orderRepository;

        public CreateOrderCommandHandler(IBookRepository bookRepository, IOrderRepository orderRepository)
        {
            this.bookRepository = bookRepository;
            this.orderRepository = orderRepository;
        }

        public CommandResult Handle(CreateOrderCommand createOrderCommand)
        {
            var resultString = new StringBuilder();
            var booksIds = new List<string>();
            foreach (var book in createOrderCommand.BooksIds)
            {
                var b = bookRepository.GetByID(Guid.Parse(book));
                if (b.Quantity <= 0)
                {
                    resultString.AppendLine($"{b.BookTitle} could not be ordered! It is not available!");
                    continue;
                }

                booksIds.Add(book);
            }

            var order = new DomainModel.Order
            {
                Address = createOrderCommand.Address,
                OrderDate = DateTime.Now,
                PhoneNumber = createOrderCommand.PhoneNumber,
            };

            var isAdded = orderRepository.Insert(order, booksIds, createOrderCommand.User);
            resultString.AppendLine();
            resultString.AppendLine(isAdded ? "Order completed" : "Could not complete the order");

            //Clear cart
            var keys = createOrderCommand.Session.Keys.Where(key => key.Contains("cart_")).ToList();
            foreach (var key in keys)
            {
                createOrderCommand.Session.Remove(key);
            }

            return new CommandResult
            {
                Result = resultString.ToString()
            };
        }
    }
}
