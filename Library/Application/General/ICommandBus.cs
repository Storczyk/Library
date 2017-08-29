using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.General
{
    public interface ICommandBus
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
