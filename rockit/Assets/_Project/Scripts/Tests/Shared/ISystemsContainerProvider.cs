using _Project.Scripts.Runtime.Core.Systems;

namespace _Project.Scripts.Tests.Shared
{
    public interface ISystemsContainerProvider
    {
        EcsSystems GetSystemsContainer();
    }
}