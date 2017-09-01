using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
