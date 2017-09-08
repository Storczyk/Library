using Library.Infrastructure.Models;

namespace Library.DomainModel
{
    public class Rating
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public ApplicationUser User { get; set; }

        public Book Book { get; set; }
    }
}
