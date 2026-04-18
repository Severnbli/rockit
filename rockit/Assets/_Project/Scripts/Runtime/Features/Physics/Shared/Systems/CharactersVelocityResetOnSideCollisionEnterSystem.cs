using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Shared.Systems
{
    public sealed class CharactersVelocityResetOnSideCollisionEnterSystem : IProtoRunSystem
    {
        [DI] private readonly PhysicsSharedAspect _psAspect;
        
        public void Run()
        {
            
        }
    }
}