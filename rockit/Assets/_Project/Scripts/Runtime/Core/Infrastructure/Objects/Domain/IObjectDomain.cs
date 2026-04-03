namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain
{
    public interface IObjectDomain
    {
        TValue Get<TValue>();
    }
}