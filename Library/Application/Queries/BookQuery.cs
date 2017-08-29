using System.ComponentModel;

namespace Library.Application.Queries
{
    public class BookQuery
    {
        public int Id { get; set; }

        [DisplayName("Title")]
        public string BookTitle { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public int Pages { get; set; }

        public string Publisher { get; set; }

        [DisplayName("ISBN")]
        public long Isbn { get; set; }

        [DisplayName("EAN")]
        public long Ean { get; set; }
    }
}
