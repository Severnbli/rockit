using Cysharp.Threading.Tasks;
using Unity.Cinemachine;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Tools.Switcher
{
    public interface ICameraSwitcher
    {
        UniTask SwitchTo(CinemachineCamera camera);
    }
}