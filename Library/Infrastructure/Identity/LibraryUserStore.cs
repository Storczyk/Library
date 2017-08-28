using Library.Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Library.Infrastructure.Identity
{
    public class LibraryUserStore : UserStore
    {
        public LibraryUserStore(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
        }
    }
}
