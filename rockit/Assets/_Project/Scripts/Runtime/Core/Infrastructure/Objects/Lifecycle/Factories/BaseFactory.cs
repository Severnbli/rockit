namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories
{
    public class BaseFactory<T>: IFactory<T>
    {
        public T Create()
        {
            PreCreate();
            var instance = CreateInstance();
            PostCreate(instance);
            return instance;
        }
        
        protected virtual void PreCreate() {}

        protected virtual T CreateInstance()
        {
            return default;
        }
        
        protected virtual void PostCreate(T instance) {}
    }
}