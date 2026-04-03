using _Project.Scripts.Runtime.Core.Systems;

namespace _Project.Scripts.Tests.Infrastructure
{
    public interface ISystemsContainerProvider
    {
        EcsSystems GetSystemsContainer();
    }
}