using Library.DomainModel;
using Library.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Library.Infrastructure.Data
{
    public class LibraryDbContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>()
                 .Ignore(i => i.EmailConfirmed)
                 .Ignore(i => i.TwoFactorEnabled)
                 .Ignore(i => i.PhoneNumber)
                 .Ignore(i => i.PhoneNumberConfirmed)
                 .Ignore(i => i.LockoutEnabled)
                 .Ignore(i => i.LockoutEnd)
                 .Ignore(i => i.AccessFailedCount)
                 .Ignore(i => i.ConcurrencyStamp)
                 .Ignore(i => i.SecurityStamp);
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserToken<string>>();            
        }
    }
}
