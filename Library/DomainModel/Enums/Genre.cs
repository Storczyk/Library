using System.ComponentModel.DataAnnotations;

namespace Library.DomainModel.Enums
{
    public enum Genre
    {
        [Display(Name = "Satire")]
        Satire,
        [Display(Name = "Drama")]
        Drama,
        Action,
        Romance,
        Horror
    }
}
