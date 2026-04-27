using _Project.Scripts.Runtime.Core.Bootstrap.States;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Project;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Services;
using Cysharp.Threading.Tasks;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Systems
{
    public sealed class SwitchToSwitchSceneStateOnSwitchSceneRequestSystems : IProtoRunSystem
    {
        [DIRequests] private readonly ScenesRequestsAspect _srAspect;
        private readonly IStateMachine _sMachine;
        private readonly SceneSwitcherService _ssService;

        public SwitchToSwitchSceneStateOnSwitchSceneRequestSystems(IStateMachine sMachine, SceneSwitcherService ssService)
        {
            _sMachine = sMachine;
            _ssService = ssService;
        }

        public void Run()
        {
            var (e, ok) = _srAspect.SwitchSceneRequests.FirstSlow();
            if (!ok) return;

            ref var ssRequest = ref _srAspect.SwitchSceneRequestPool.Get(e);
            _ssService.Target = ssRequest.Target;
            
            _sMachine.ChangeState<SwitchSceneState>().Forget();
        }
    }
}