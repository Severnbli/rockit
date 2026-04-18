using _Project.Scripts.Runtime.Features.Physics.Shared.Services;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Shared.Systems
{
    public sealed class CharactersVelocityResetOnSideCollisionEnterSystem : IProtoRunSystem
    {
        [DI] private readonly PhysicsSharedAspect _psAspect;
        [DI] private readonly SharedAspect _sAspect;
        private readonly PhysicsService _pService;

        public CharactersVelocityResetOnSideCollisionEnterSystem(PhysicsService pService)
        {
            _pService = pService;
        }
        
        public void Run()
        {
            
        }
    }
}