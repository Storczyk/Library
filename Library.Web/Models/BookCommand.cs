using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Web.Models
{
    public class BookCommand
    {
        [Required]
        [DisplayName("Title")]
        public string BookTitle { get; set; }

        [Required]
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
