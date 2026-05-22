using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Systems
{
    public sealed class DisableConstantOnInitializeRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly SharedRequestsAspect _srAspect;
        [DI] private readonly ConstantsAspect _cAspect;
        private readonly DataProvider _dProvider;
        private ProtoWorld _world;

        public DisableConstantOnInitializeRequestSystem(DataProvider dProvider)
        {
            _dProvider = dProvider;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var reqE in _srAspect.InitializeRunRequests)
            {
                if (!_rAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_cAspect.Constants.Has(tarE)) continue;

                ref var cComponent = ref _cAspect.ConstantComponentPool.Get(tarE);

                if (!_dProvider.StatsData.InvestigatedConstants.ContainsKey(cComponent.Id)) continue;

                var packed = _world.PackEntityWithWorld(tarE);
                SharedUtils.CreateDisableRequest(_rAspect, packed);
            }
        }
    }
}