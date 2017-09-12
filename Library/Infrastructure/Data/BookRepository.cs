using Library.Application.Queries;
using Library.Application.Queries.Books;
using Library.DomainModel;
using Library.DomainModel.Enums;
using Library.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Library.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public BookRepository(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server=PSROCZYK-RZE\\SQLEXPRESS;Database=libraryDB;User Id=test;Password=test;MultipleActiveResultSets=True");
            context = new LibraryDbContext(options.Options);
        }

        public PaginatedList<BookQuery> Get(int page = 1, int pageSize = 10)
        {
            var books = PaginatedList<BookQuery>.Create(context.Books.Include(i => i.Ratings).OrderBy(i => i.BookTitle)
                .Select(i => new BookQuery
                {
                    Author = i.Author,
                    BookTitle = i.BookTitle,
                    Description = i.Description,
                    Ean = i.Ean,
                    Genre = i.Genre,
                    Id = i.BookId.ToString(),
                    Isbn = i.Isbn,
                    Pages = i.Pages,
                    Publisher = i.Publisher,
                    Quantity = i.Quantity,
                    Year = i.Year,
                    Image = i.Image,
                    Rating = i.Ratings.Any() ? i.Ratings.Average(j => j.Value) : 0
                })
                .AsQueryable(), page, pageSize);

            return books;
        }

        public IEnumerable<BookQuery> Get(string[] booksIds)
        {
            var books = context.Books.Where(i => booksIds.Contains(i.BookId.ToString()))
                .Include(i => i.Author).Include(i => i.Ratings)
                .OrderByDescending(i => i.BookTitle)
                .Select(i => new BookQuery
            {
                Author = i.Author,
                Genre = i.Genre,
                BookTitle = i.BookTitle,
                Description = i.Description,
                Ean = i.Ean,
                Id = i.BookId.ToString(),
                Isbn = i.Isbn,
                Pages = i.Pages,
                Publisher = i.Publisher,
                Year = i.Year,
                Image = i.Image,
                Rating = i.Ratings.Any() ? i.Ratings.Average(j => j.Value) : 0
            }).ToList();

            return books;
        }

        public bool Insert(Book entity)
        {
            try
            {
                var author = context.Authors.FirstOrDefault(i => i.Name == entity.Author.Name);
                if (author != null)
                {
                    entity.Author = author;
                }

                context.Books.Add(entity);
                if (context.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                context.Books.Remove(GetByID(id));
                if (context.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Book entityToUpdate)
        {
            try
            {
                var author = context.Authors.FirstOrDefault(i => i.Name == entityToUpdate.Author.Name);
                if (author != null)
                {
                    entityToUpdate.Author = author;
                }

                context.Books.Update(entityToUpdate);
                if (context.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public Book GetByID(Guid id, bool isWithAuthor = true)
        {
            if (isWithAuthor)
            {
                return context.Books.Where(i => i.BookId == id).Include(i => i.Author).FirstOrDefault();
            }

            return context.Books.Where(i => i.BookId == id).FirstOrDefault();
        }

        public PaginatedList<BookQuery> GetByTitle(string title, int page, int pageSize)
        {
            return PaginatedList<BookQuery>.Create(context.Books
                .Where(i => i.BookTitle.Contains(title))
                .OrderByDescending(i => i.BookTitle)
                .Select(i => new BookQuery
                {
                    Author = i.Author,
                    Genre = i.Genre,
                    BookTitle = i.BookTitle,
                    Description = i.Description,
                    Ean = i.Ean,
                    Id = i.BookId.ToString(),
                    Isbn = i.Isbn,
                    Pages = i.Pages,
                    Publisher = i.Publisher,
                    Year = i.Year,
                    Quantity = i.Quantity,
                    Image = i.Image,
                    Rating = i.Ratings.Any() ? i.Ratings.Average(j => j.Value) : 0
                }).AsQueryable(), page, pageSize, title);
        }

        public PaginatedList<BookQuery> GetByGenre(Genre genre, int page, int pageSize)
        {
            return PaginatedList<BookQuery>.Create(
                context.Books.Where(i => i.Genre == genre)
                .OrderByDescending(i => i.BookTitle)
                .Select(i => new BookQuery
                {
                    Author = i.Author,
                    BookTitle = i.BookTitle,
                    Description = i.Description,
                    Ean = i.Ean,
                    Genre = i.Genre,
                    Id = i.BookId.ToString(),
                    Isbn = i.Isbn,
                    Pages = i.Pages,
                    Publisher = i.Publisher,
                    Quantity = i.Quantity,
                    Year = i.Year,
                    Image = i.Image,
                    Rating = i.Ratings.Any() ? i.Ratings.Average(j => j.Value) : 0
                }), page, pageSize, genre: genre);
        }

        public bool AddRating(string bookId, int value, ClaimsPrincipal userPrincipal)
        {
            try
            {
                var userId = userManager.GetUserId(userPrincipal);
                var book = context.Books.Find(Guid.Parse(bookId));
                var user = context.Users.Find(userId);

                context.Ratings.Add(new Rating
                {
                    Book = book,
                    User = user,
                    Value = value
                });

                return context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
