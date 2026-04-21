using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
using _Project.Scripts.Runtime.Shared.Utils.Moving;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Shared.Systems
{
    public sealed class UpdateMoveDirectionByVelocitySystem : IProtoRunSystem
    {
        [DI] private readonly PhysicsSharedAspect _psAspect;
        [DI] private readonly MovingSharedAspect _mSharedAspect;
        
        public void Run()
        {
            foreach (var e in _mSharedAspect.Rigidbody2DMovables)
            {
                ref var rComponent = ref _psAspect.Rigidbody2DComponentPool.Get(e);
                if (rComponent.Rigidbody2D.VelocityXZero()) continue;
                
                ref var mComponent = ref _mSharedAspect.MoveComponentPool.GetOrAdd(e);
                mComponent.Direction = CharactersMovingUtils.GetMoveDirectionByVector2(rComponent.Rigidbody2D.linearVelocity);
            }
        }
    }
}