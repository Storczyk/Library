using Library.Application.General;
using Library.DomainModel;
using Library.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void Handle(CreateOrderCommand createOrderCommand)
        {
            var booksIds = new List<string>();
            foreach(var book in createOrderCommand.BooksIds)
            {
                var b = bookRepository.GetByID(Guid.Parse(book));
                if(b.Quantity <= 0)
                {
                    continue;
                }

                booksIds.Add(book);
            }

            var order = new Library.DomainModel.Order
            {               
                Address = createOrderCommand.Address,
                OrderDate = DateTime.Now,
                PhoneNumber = createOrderCommand.PhoneNumber,
            };
            orderRepository.Insert(order, booksIds, createOrderCommand.User);

            //Clear cart
            var keys = createOrderCommand.Session.Keys.Where(key => key.Contains("cart_")).ToList();
            foreach(var key in keys)
            {
                createOrderCommand.Session.Remove(key);
            }
        }
    }
}
