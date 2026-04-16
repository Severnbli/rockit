using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Shared.Systems
{
    public sealed class PhysicsServiceUpdateSystem : IProtoRunSystem
    {
        [DI] private readonly PhysicsSharedAspect _physicsSharedAspect;
        
        public void Run()
        {
            
        }
    }
}