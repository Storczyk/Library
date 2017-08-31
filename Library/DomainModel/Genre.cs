using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.DomainModel
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        public string Description { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
