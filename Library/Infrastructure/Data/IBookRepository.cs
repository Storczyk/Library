using Library.Application.Queries;
using Library.Application.Queries.Books;
using Library.DomainModel;
using Library.DomainModel.Enums;
using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Data
{
    public interface IBookRepository
    {
        PaginatedList<BookQuery> Get(int page = 1, int pageSize = 10);

        IEnumerable<BookQuery> Get(string[] booksIds);

        Book GetByID(Guid id, bool isWithAuthor = true);

        PaginatedList<BookQuery> GetByTitle(string title, int page, int pageSize);

        bool Insert(Book entity);

        bool Delete(Guid id);

        bool Update(Book entityToUpdate);

        PaginatedList<BookQuery> GetByGenre(Genre genre, int page, int pageSize);
    }
}
