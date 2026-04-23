using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization.Systems
{
    public sealed class SendUpdateLocalizationItemOnInitializeRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly SharedRequestsAspect _srAspect;
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly LocalizationAspect _lAspect;
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var reqE in _srAspect.InitializeRunRequests)
            {
                if (!_rAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_lAspect.LocalizationItems.Has(tarE)) continue;
                
                var packed = _world.PackEntityWithWorld(tarE);
                
                LocalizationUtils.CreateUpdateLocalizationItemRequest(_rAspect, packed);
            }
        }
    }
}