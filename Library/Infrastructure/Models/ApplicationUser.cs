using Library.DomainModel;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Library.Infrastructure.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Order> Orders { get; set; }
    }
}
