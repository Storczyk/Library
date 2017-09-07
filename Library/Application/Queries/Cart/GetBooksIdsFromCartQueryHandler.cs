using Library.Application.General;
using System.Collections.Generic;

namespace Library.Application.Queries.Cart
{
    public class GetBooksIdsFromCartQueryHandler : IQueryHandler<GetBooksIdsFromCartQuery, IEnumerable<string>>
    {
        private readonly string Cart = "cart_";

        public IEnumerable<string> Handle(GetBooksIdsFromCartQuery query)
        {
            var keys = query.CurrentSession.Keys;
            var bookIdsList = new List<string>();
            foreach (var item in keys)
            {
                if (!item.Contains(Cart))
                {
                    continue;
                }

                bookIdsList.Add(item.Replace(Cart, ""));
            }

            return bookIdsList;
        }
    }
}
