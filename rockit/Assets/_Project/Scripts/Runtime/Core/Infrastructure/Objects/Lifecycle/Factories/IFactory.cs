namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories
{
    public interface IFactory<out T> where T : new ()
    {
        T Create();
    }
}