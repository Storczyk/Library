using Library.Application.Queries.Books;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Library.Web.Extensions
{
    public static class SessionExtensions
    {
        public static void StoreBookInCartAsJson(
            this ISession session,
            string key,
            BookQuery value)
        {
            var c = JsonConvert.SerializeObject(value);
            session.SetString(key, c);
        }

        public static BookQuery GetBookInCartAsJson<BookQuery>(
            this ISession session,
            string key)
        {
            var value = session.GetString(key);

            return value == null ? default(BookQuery) : JsonConvert.DeserializeObject<BookQuery>(value);
        }
    }
}
