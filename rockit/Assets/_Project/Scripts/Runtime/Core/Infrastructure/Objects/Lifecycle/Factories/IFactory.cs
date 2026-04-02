namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories
{
    public interface IFactory<out T>
    {
        T Create();
    }
}