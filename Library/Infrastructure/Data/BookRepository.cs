using Library.Application.Logger;
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
        private readonly LibraryDbContext context;

        public BookRepository()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server=PSROCZYK-RZE\\SQLEXPRESS;Database=libraryDB;User Id=test;Password=test;MultipleActiveResultSets=True");
            context = new LibraryDbContext(options.Options);
        }

        public IEnumerable<Book> Get(int page = 1, int pageSize = 10)
        {
            return context.Books.Skip(pageSize * (page - 1)).Take(pageSize).Include(i => i.Author).ToList();
        }

        public IEnumerable<BookQuery> Get(string[] filters)
        {
            return context.Books.Where(i => filters.Contains(i.BookId.ToString())).Include(i => i.Author).Select(i => new BookQuery
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
            catch (Exception exception)
            {
                Logger.Log(exception.Message);
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
            catch (Exception exception)
            {
                Logger.Log(exception.Message);
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
            catch (Exception exception)
            {
                Logger.Log(exception.Message);
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
    }
}
