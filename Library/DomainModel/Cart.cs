using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.DomainModel
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }

        public DateTime DateCreated { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
