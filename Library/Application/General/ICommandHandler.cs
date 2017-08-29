using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.General
{
    public interface ICommandHandler
    {
    }
    public interface ICommandHanlder<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
