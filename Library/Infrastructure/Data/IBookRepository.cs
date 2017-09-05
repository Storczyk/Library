using Library.Application.Queries.Books;
using Library.DomainModel;
using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Data
{
    public interface IBookRepository
    {
        IEnumerable<Book> Get(int page = 1, int pageSize = 10);

        IEnumerable<BookQuery> Get(string[] filters);

        Book GetByID(Guid id, bool isWithAuthor = true);

        bool Insert(Book entity);

        bool Delete(Guid id);

        bool Update(Book entityToUpdate);
    }
}
