namespace ApplicationCore.Interfaces
{
    public interface ICommandService<T>
    {
        void Execute(T command);
    }
}
