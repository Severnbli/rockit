using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;

namespace _Project.Scripts.Tests.Systems
{
    public class SystemsContainerProvider : ISystemsContainerProvider
    {
        public EcsSystems GetSystemsContainer()
        {
            var world = new ProtoWorld(new DomainAspect());
            return null;
        }
    }
}