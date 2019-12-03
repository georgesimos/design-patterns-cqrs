using System.Collections;
using DesignPatterns.Commands;

namespace DesignPatterns.Handlers
{
    /// <summary>
    /// Defines a handler for a command.
    /// </summary>
    /// <typeparam name="T">Command type being handled</typeparam>
    /// 
    public interface ICommandHandler<TCommand> 
    {
        void Handle(TCommand command);
    }
}