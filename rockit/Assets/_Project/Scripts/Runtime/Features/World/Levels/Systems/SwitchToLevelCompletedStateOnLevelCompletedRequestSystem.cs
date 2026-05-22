using _Project.Scripts.Runtime.Core.Bootstrap.States;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using Cysharp.Threading.Tasks;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class SwitchToLevelCompletedStateOnLevelCompletedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        private readonly IStateMachine _sMachine;

        public SwitchToLevelCompletedStateOnLevelCompletedRequestSystem(IStateMachine sMachine)
        {
            _sMachine = sMachine;
        }

        public void Run()
        {
            if (_lrAspect.LevelCompletedRequests.IsEmptySlow()) return;

            _sMachine.ChangeState<LevelCompletedState>().Forget();
        }
    }
}