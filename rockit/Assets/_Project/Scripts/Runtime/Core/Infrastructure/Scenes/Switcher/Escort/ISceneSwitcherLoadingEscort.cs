using System.ComponentModel;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Escort
{
    public interface ISceneSwitcherLoadingEscort
    {
        UniTask EscortLoading(AsyncOperation operation, SceneSwitcherService service);
    }
}