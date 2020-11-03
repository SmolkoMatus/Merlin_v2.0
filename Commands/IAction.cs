namespace Merlin_v2._0.Commands
{
    public interface IAction<T>
    {
        void Execute(T t);
    }
}
