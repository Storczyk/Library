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
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;
            return context.Books.Skip(pageSize * (page - 1)).Take(pageSize).Include(i => i.Author).Include(i => i.Genre).ToList();
        }
        public Book GetByID(Guid id)
        {
            return context.Books.Find(id);
        }

        public void Insert(Book entity)
        {
            var author = context.Authors.FirstOrDefault(i => i.FirstName == entity.Author.FirstName && i.LastName == entity.Author.LastName);
            if (author != null)
                entity.Author = author;
            var genre = context.Genres.FirstOrDefault(i => i.Description ==entity.Description);
            if (genre != null)
                entity.Genre = genre;

            context.Books.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            context.Books.Remove(GetByID(id));
            context.SaveChanges();
        }

        public void Update(Book entityToUpdate)
        {
            var author = context.Authors.FirstOrDefault(i => i.FirstName == entityToUpdate.Author.FirstName && i.LastName == entityToUpdate.Author.LastName);
            if (author != null)
                entityToUpdate.Author = author;
            var genre = context.Genres.FirstOrDefault(i => i.Description == entityToUpdate.Description);
            if (genre != null)
                entityToUpdate.Genre = genre;


            context.Books.Update(entityToUpdate);
            context.SaveChanges();
        }
    }
}
