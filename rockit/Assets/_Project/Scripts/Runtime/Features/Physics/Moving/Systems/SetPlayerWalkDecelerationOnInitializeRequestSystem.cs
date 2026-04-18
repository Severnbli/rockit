using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class SetPlayerWalkDecelerationOnInitializeRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly SharedRequestsAspect _srAspect;
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DI] private readonly SharedAspect _sAspect;
        [DI] private readonly MovingAspect _mAspect;
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