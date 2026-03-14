using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States
{
    public interface IState
    {
        UniTask OnEnter();
        UniTask OnLeave();
    }
}