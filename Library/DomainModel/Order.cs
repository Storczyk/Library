using Library.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.DomainModel
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
