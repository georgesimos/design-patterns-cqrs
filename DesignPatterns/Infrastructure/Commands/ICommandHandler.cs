using DesignPatterns.Commands;

namespace DesignPatterns.Handlers
{
    /// <summary>
    /// Defines a handler for a command.
    /// </summary>
    /// <typeparam name="T">Command type being handled</typeparam>
    /// 
    public interface ICommandHandler
    {
    }

    public interface ICommandHandler<T> : ICommandHandler
         where T : ICommand
    {
        void Handle(T command);
    }
}