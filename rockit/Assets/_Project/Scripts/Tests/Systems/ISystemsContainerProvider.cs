using _Project.Scripts.Runtime.Core.Systems;

namespace _Project.Scripts.Tests.Systems
{
    public interface ISystemsContainerProvider
    {
        EcsSystems GetSystemsContainer();
    }
}