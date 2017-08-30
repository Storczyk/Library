using Library.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data
{
    public interface IBookRepository
    {
        IEnumerable<Book> Get(int page = 1, int pageSize = 10);
        Book GetByID(Guid id);
        void Insert(Book entity);
        void Delete(Guid id);
        void Update(Book entityToUpdate);
    }
}
