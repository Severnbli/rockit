using _Project.Scripts.Runtime.Core.Systems;

namespace _Project.Scripts.Tests
{
    public interface ISystemsContainerProvider
    {
        EcsSystems GetSystemsContainer();
    }
}