using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Escort
{
    public interface ISceneLoadingEscort
    {
        UniTask EscortLoading(AsyncOperation operation);
    }
}