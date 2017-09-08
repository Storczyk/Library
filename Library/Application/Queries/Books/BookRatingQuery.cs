using System.ComponentModel;

namespace Library.Application.Queries.Books
{
    public class BookRatingQuery
    {
        public string Id { get; set; }

        [DisplayName("Title")]
        public string BookTitle { get; set; }

        public bool IsRated { get; set; }
    }
}
