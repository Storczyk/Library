using Library.Application.General;
using Library.DomainModel;
using Library.Infrastructure.Data;
using System;
using System.Collections.Generic;

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

        public void Handle(CreateOrderCommand command)
        {
            var order = new Library.DomainModel.Order
            {
                Address = command.Address,
                OrderDate = DateTime.Now,
                PhoneNumber = command.PhoneNumber,
            };
            //var orderId = orderRepository.Insert(order);


            orderRepository.Insert(order, command.BooksIds);
            var x = orderRepository.GetAll(1, 10);

        }
    }
}
