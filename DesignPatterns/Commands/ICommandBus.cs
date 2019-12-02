namespace DesignPatterns.Commands
{
    public interface ICommandBus
    {
        void Send<T>(T Command) where T : ICommand;
    }
}