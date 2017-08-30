using Library.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Library.Infrastructure.Data
{
    public class BookRepository
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
            return context.Books.Skip(pageSize * (page - 1)).Take(pageSize);
        }
        public Book GetByID(Guid id)
        {
            return context.Books.Find(id);
        }

        public  void Insert(Book entity)
        {
            context.Books.Add(entity);
            context.SaveChanges();
        }

        public virtual void Delete(Guid id)
        {
            context.Books.Remove(GetByID(id));
            context.SaveChanges();
        }


        public virtual void Update(Book entityToUpdate)
        {
            context.Books.Update(entityToUpdate);
            context.SaveChanges();
        }
    }
}
