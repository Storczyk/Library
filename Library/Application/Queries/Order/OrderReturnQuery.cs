using System.ComponentModel;

namespace Library.Application.Queries.Order
{
    public class OrderReturnQuery
    {
        public OrderDetailQuery Order { get; set; }

        [DisplayName("User's ID")]
        public string UserId { get; set; }

        [DisplayName("User's Email")]
        public string UserEmail { get; set; }
    }
}
