using Library.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data
{
    public class LibraryDbContext:IdentityDbContext<ApplicationUser>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options):base(options)
        {

        }
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
            builder.Ignore<IdentityRoleClaim<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
            builder.Ignore<IdentityUserToken<string>>();
        }
    }
}
