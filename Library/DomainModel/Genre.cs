using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.DomainModel
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
