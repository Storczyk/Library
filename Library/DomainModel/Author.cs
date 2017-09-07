using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.DomainModel
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }

    }
}
