using Library.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Queries.Order
{
    public class OrderReturnQuery
    {
        public OrderDetailQuery Order { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
    }
}
