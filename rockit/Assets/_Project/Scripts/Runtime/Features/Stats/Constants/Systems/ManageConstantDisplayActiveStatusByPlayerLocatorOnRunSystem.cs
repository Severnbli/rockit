using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.Stats.Constants.Configs;
using _Project.Scripts.Runtime.Shared.Extensions.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Systems
{
    public sealed class ManageConstantDisplayActiveStatusByPlayerLocatorOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly ConstantsAspect _cAspect;
        [DI] private readonly SharedAspect _sAspect;
        private readonly ConstantsDisplaysConfig _cdConfig;

        public ManageConstantDisplayActiveStatusByPlayerLocatorOnRunSystem(ConstantsDisplaysConfig cdConfig)
        {
            _cdConfig = cdConfig;
        }

        public void Run()
        {
            foreach (var e in _cAspect.PlayerLocatorConstantDisplays)
            {
                ref var plComponent = ref _sAspect.PlayerLocatorComponentPool.Get(e);
                var inActiveDistance = plComponent.Distance <= _cdConfig.ActivateDistance;
                _cAspect.ConstantActiveDisplayTagPool.AddOrDelOnCondition(e, inActiveDistance);
            }
        }
    }
}