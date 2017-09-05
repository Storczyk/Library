using Library.Application.Queries.Books;
using Library.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookRepository()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server=PSROCZYK-RZE\\SQLEXPRESS;Database=libraryDB;User Id=test;Password=test;MultipleActiveResultSets=True");
            libraryDbContext = new LibraryDbContext(options.Options);
        }

        public IEnumerable<Book> Get(int page = 1, int pageSize = 10)
        {
            if (page < 1)
            {
                page = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 10;
            }

            return libraryDbContext.Books.Skip(pageSize * (page - 1)).Take(pageSize).Include(i => i.Author).ToList();
        }

        public IEnumerable<BookQuery> Get(string[] filters)
        {
            var books = libraryDbContext.Books.Where(i => filters.Contains(i.BookId.ToString())).Include(i => i.Author).Select(i => new BookQuery
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
            }).ToList();

            return books;
        }

        public bool Insert(Book entity)
        {
            var author = libraryDbContext.Authors.FirstOrDefault(i => i.Name == entity.Author.Name);
            if (author != null)
            {
                entity.Author = author;
            }

            libraryDbContext.Books.Add(entity);
            libraryDbContext.SaveChanges();

            return true;
        }

        public bool Delete(Guid id)
        {
            libraryDbContext.Books.Remove(GetByID(id));
            libraryDbContext.SaveChanges();

            return true;
        }

        public bool Update(Book entityToUpdate)
        {
            var author = libraryDbContext.Authors.FirstOrDefault(i => i.Name == entityToUpdate.Author.Name);
            if (author != null)
            {
                entityToUpdate.Author = author;
            }

            libraryDbContext.Books.Update(entityToUpdate);
            libraryDbContext.SaveChanges();

            return true;
        }

        public Book GetByID(Guid id, bool isWithAuthor = true)
        {
            if (isWithAuthor)
            {
                return libraryDbContext.Books.Where(i => i.BookId == id).Include(i => i.Author).FirstOrDefault();
            }

            return libraryDbContext.Books.Where(i => i.BookId == id).FirstOrDefault();
        }
    }
}
