using _Project.Scripts.Runtime.Core.Bootstrap.States;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using Cysharp.Threading.Tasks;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Systems
{
    public sealed class HideConstantDisplayWindowOnHideConstantDisplayWindowRequest : IProtoRunSystem
    {
        [DIRequests] private readonly ConstantsRequestsAspect _crAspect;
        private readonly IStateMachine _sMachine;

        public HideConstantDisplayWindowOnHideConstantDisplayWindowRequest(IStateMachine sMachine)
        {
            _sMachine = sMachine;
        }

        public void Run()
        {
            if (_crAspect.HideConstantDisplayWindowRequests.IsEmptySlow()) return;

            _sMachine.LeaveModalState<IConstantDisplayState>().Forget();
        }
    }
}