using Library.Application.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Commands.Order
{
    public class ReturnBookCommand:ICommand
    {
        public string OrderDetailId { get; set; }
    }
}
