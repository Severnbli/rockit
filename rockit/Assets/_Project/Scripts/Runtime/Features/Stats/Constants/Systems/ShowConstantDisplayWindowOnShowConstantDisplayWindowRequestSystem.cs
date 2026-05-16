using _Project.Scripts.Runtime.Core.Bootstrap.States;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Stats.Constants.Services;
using Cysharp.Threading.Tasks;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Systems
{
    public sealed class ShowConstantDisplayWindowOnShowConstantDisplayWindowRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly ConstantsRequestsAspect _crAspect;
        private readonly ConstantDisplayWindowService _cdwService;
        private readonly IStateMachine _sMachine;

        public ShowConstantDisplayWindowOnShowConstantDisplayWindowRequestSystem(ConstantDisplayWindowService cdwService, 
            IStateMachine sMachine)
        {
            _cdwService = cdwService;
            _sMachine = sMachine;
        }

        public void Run()
        {
            if (_crAspect.ShowConstantDisplayWindowRequests.IsEmptySlow()) return;
            if (!_cdwService.Show) return;

            _sMachine.EnterModalState<IConstantDisplayState>().Forget();
        }
    }
}