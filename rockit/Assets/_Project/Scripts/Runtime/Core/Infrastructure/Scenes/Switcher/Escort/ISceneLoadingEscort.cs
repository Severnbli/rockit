using UnityEngine;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Escort
{
    public interface ISceneLoadingEscort
    {
        UniTask EscortLoading(AsyncOperation operation, SceneSwitcherService service);
    }
}