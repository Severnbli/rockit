using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization.Systems
{
    public sealed class SendUpdateLocalizationItemRequestOnLocalizationUpdatedRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly LocalizationRequestsAspect _lrAspect;
        [DI] private readonly LocalizationAspect _lAspect;
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            if (_lrAspect.LocalizationUpdatedRequests.IsEmptySlow()) return;
            
            foreach (var liEntity in _lAspect.LocalizationItems)
            {
                var packed = _world.PackEntityWithWorld(liEntity);
                LocalizationUtils.CreateUpdateLocalizationItemRequest(_rAspect, packed);
            }
        }
    }
}