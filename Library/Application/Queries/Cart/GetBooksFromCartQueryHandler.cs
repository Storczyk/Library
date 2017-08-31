using Library.Application.General;
using Library.Application.Queries.Books;
using Library.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Queries.Cart
{
    public class GetBooksFromCartQueryHandler : IQueryHandler<GetBooksFromCartQuery, IEnumerable<BookQuery>>
    {
        private readonly IBookRepository bookRepository;
        public GetBooksFromCartQueryHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public IEnumerable<BookQuery> Handle(GetBooksFromCartQuery query)
        {
            var keys = query.CurrentSession.Keys;
            var bookIdsList = new List<string>();
            foreach(var item in keys)
            {
                if (!item.Contains("cart_"))
                {
                    continue;
                }
                bookIdsList.Add(item);
            }
            return bookRepository.Get(bookIdsList.ToArray());
        }
    }
}
