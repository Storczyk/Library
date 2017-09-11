using Library.Application.Queries;
using Library.Application.Queries.Books;
using Library.DomainModel;
using Library.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Library.Infrastructure.Data
{
    public interface IBookRepository
    {
        /// <summary>
        /// Gets paginated list of book. 
        /// </summary>
        /// <param name="page">Page index</param>
        /// <param name="pageSize">Items per Page</param>
        PaginatedList<BookQuery> Get(int page = 1, int pageSize = 10);

        /// <summary>
        /// Gets books displayed in cart.
        /// </summary>
        /// <param name="booksIds">List of books Ids</param>
        IEnumerable<BookQuery> Get(string[] booksIds);

        /// <summary>
        /// Gets specific book
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <param name="isWithAuthor">If author is included</param>
        Book GetByID(Guid id, bool isWithAuthor = true);

        /// <summary>
        /// Gets paged list of books that contains specific title
        /// </summary>
        /// <param name="title">Title to search</param>
        /// <param name="page">Page Index</param>
        /// <param name="pageSize">Items per page</param>
        PaginatedList<BookQuery> GetByTitle(string title, int page, int pageSize);

        /// <summary>
        /// Gets paged list of books by specific genre
        /// </summary>
        /// <param name="genre">Genre</param>
        /// <param name="page">Page index</param>
        /// <param name="pageSize">Items per page</param>
        PaginatedList<BookQuery> GetByGenre(Genre genre, int page, int pageSize);

        /// <summary>
        /// Adds book to database
        /// </summary>
        /// <param name="entity">Book to add</param>
        bool Insert(Book entity);

        /// <summary>
        /// Deletes book from database
        /// </summary>
        /// <param name="id">Book id</param>
        bool Delete(Guid id);

        /// <summary>
        /// Updates book in database
        /// </summary>
        /// <param name="entityToUpdate">Updated book entity</param>
        bool Update(Book entityToUpdate);

        /// <summary>
        /// Adds rate to book
        /// </summary>
        /// <param name="bookId">Rated book</param>
        /// <param name="value">Rate value</param>
        /// <param name="userPrincipal">User principal(Used to get logged in user)</param>
        bool AddRating(string bookId, int value, ClaimsPrincipal userPrincipal);
    }
}
