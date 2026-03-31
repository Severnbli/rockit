using System.ComponentModel;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher
{
    public interface ISceneSwitcherLoadingEscort
    {
        UniTask EscortLoading(AsyncOperation operation, SceneSwitcherService service);
    }
}