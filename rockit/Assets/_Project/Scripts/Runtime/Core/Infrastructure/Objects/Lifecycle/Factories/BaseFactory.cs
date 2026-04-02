namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories
{
    public class BaseFactory<T>: IFactory<T>
    {
        public T Create()
        {
            return default;
        }
    }
}