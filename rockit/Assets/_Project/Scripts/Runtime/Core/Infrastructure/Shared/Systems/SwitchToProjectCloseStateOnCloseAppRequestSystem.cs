using _Project.Scripts.Runtime.Core.Bootstrap.States;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Project;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using Cysharp.Threading.Tasks;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Systems
{
    public sealed class SwitchToProjectCloseStateOnCloseAppRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly SharedRequestsAspect _srAspect;
        private readonly IStateMachine _sMachine;

        public SwitchToProjectCloseStateOnCloseAppRequestSystem(IStateMachine sMachine)
        {
            _sMachine = sMachine;
        }

        public void Run()
        {
            if (_srAspect.CloseAppRequests.IsEmptySlow()) return;

            _sMachine.ChangeState<IProjectCloseState>().Forget();
        }
    }
}