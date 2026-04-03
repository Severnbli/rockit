using Zenject;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain
{
    public class DiContainerDomainObjectInstantiator : IDomainObjectInstantiator
    {
        protected readonly DiContainer Container;

        public DiContainerDomainObjectInstantiator(DiContainer container)
        {
            Container = container;
        }

        public TValue Instantiate<TValue>()
        {
            return Container.Instantiate<TValue>();
        }
    }
}