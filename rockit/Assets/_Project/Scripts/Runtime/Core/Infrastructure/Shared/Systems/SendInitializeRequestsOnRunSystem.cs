using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Systems
{
    public sealed class SendInitializeRequestsOnRunSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly SharedAspect _sAspect;
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }
        
        public void Run()
        {
            
        }
    }
}