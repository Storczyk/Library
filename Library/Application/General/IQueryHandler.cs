namespace Library.Application.General
{
    public interface IQueryHandler
    {
    }
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
