using Autofac;

namespace Library.Application.General
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext componentContext;
        public QueryDispatcher(IComponentContext context)
        {
            this.componentContext = context;
        }

        public TResult Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var handler = componentContext.Resolve<IQueryHandler<TQuery, TResult>>();
            return handler.Handle(query);
        }
    }
}
