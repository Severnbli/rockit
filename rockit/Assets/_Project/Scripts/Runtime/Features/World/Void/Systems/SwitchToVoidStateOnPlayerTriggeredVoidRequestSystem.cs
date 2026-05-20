using _Project.Scripts.Runtime.Core.Bootstrap.States;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Player;
using Cysharp.Threading.Tasks;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Void.Systems
{
    public sealed class SwitchToVoidStateOnPlayerTriggeredVoidRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly PlayerRequestsAspect _prAspect;
        private readonly IStateMachine _sMachine;

        public SwitchToVoidStateOnPlayerTriggeredVoidRequestSystem(IStateMachine sMachine)
        {
            _sMachine = sMachine;
        }

        public void Run()
        {
            if (_prAspect.PlayerTriggeredVoidRequests.IsEmptySlow()) return;

            _sMachine.ChangeState<VoidState>().Forget();
        }
    }
}