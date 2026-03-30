using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public interface IDataStorage
    {
        UniTask Load<T>();
        UniTask Save<T>(T item);
    }
}