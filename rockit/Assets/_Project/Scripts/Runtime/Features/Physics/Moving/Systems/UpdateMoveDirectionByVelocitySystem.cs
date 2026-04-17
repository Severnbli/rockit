using _Project.Scripts.Runtime.Features.Physics.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class UpdateMoveDirectionByVelocitySystem : IProtoRunSystem
    {
        [DI] private readonly PhysicsSharedAspect _psAspect;
        
        public void Run()
        {
            
        }
    }
}