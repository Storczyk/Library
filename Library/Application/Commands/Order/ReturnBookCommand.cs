using Library.Application.General;

namespace Library.Application.Commands.Order
{
    public class ReturnBookCommand:ICommand
    {
        public string OrderDetailId { get; set; }
    }
}
