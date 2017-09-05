using Autofac;

namespace Library.Application.General
{
    public class CommandBus : ICommandBus
    {
        private readonly IComponentContext componentContext;

        public CommandBus(IComponentContext context)
        {
            this.componentContext = context;
        }

        public CommandResult Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = componentContext.Resolve<ICommandHandler<TCommand>>();
            var result = handler.Handle(command);

            return result;
        }
    }
}
