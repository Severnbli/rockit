using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class UpdateMoveDirectionByVelocitySystem : IProtoRunSystem
    {
        [DI] private readonly PhysicsSharedAspect _psAspect;
        [DI] private readonly MovingAspect _mAspect;
        
        public void Run()
        {
            foreach (var e in _mAspect.Rigidbody2DMovables)
            {
                ref var rComponent = ref _psAspect.Rigidbody2DComponentPool.Get(e);
                if (rComponent.Rigidbody2D.VelocityXZero()) continue;
                
                ref var mComponent = ref _mAspect.MoveComponentPool.GetOrAdd(e);
                mComponent.Direction = MovingUtils.GetMoveDirectionByVector2(rComponent.Rigidbody2D.linearVelocity);
            }
        }
    }
}