using Library.Application.General;

namespace Library.Application.Queries.GetBook
{
    public class GetBookQueryHandler : IQueryHandler<GetBookQuery, BookQuery>
    {
        public BookQuery Handle(GetBookQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}
