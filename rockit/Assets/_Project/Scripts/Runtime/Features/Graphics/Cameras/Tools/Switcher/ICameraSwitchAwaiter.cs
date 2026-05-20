using System.Threading;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Tools.Switcher
{
    public interface ICameraSwitchAwaiter
    {
        UniTask AwaitSwitch(CancellationToken ct = default);
    }
}