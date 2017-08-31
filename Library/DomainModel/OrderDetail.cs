using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.DomainModel
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailId { get; set; }

        public Guid OrderId { get; set; }
        public Guid BookId { get; set; }

        public Order Order { get; set; }
        public Book Book { get; set; }
    }
}
