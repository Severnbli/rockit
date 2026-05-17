using _Project.Scripts.Runtime.Core.Engine;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Shared.Active
{
    public abstract class SceneSetupState : ISceneSetupState
    {
        protected readonly IEngine Engine;

        protected SceneSetupState(IEngine engine)
        {
            Engine = engine;
        }

        public virtual UniTask OnEnter(IStateMachine stateMachine)
        {
            Engine.Init();
            ScenesUtils.InitializeScene();
            return UniTask.CompletedTask;
        }

        public virtual UniTask OnLeave(IStateMachine stateMachine)
        {
            return UniTask.CompletedTask;
        }
    }
}