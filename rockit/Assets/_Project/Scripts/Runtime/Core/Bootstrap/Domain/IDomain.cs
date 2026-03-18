using _Project.Scripts.Runtime.Core.Bootstrap.Modules;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public interface IDomain
    {
        bool TryRegisterModule<T>() where T : BaseModule<T>;
    }
}