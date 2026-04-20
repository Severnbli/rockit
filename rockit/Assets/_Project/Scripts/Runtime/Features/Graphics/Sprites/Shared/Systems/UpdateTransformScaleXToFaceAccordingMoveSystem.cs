using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.Physics.Moving;
using _Project.Scripts.Runtime.Features.Physics.Moving.Shared;
using _Project.Scripts.Runtime.Shared.Utils.Graphics.Sprites;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Sprites.Shared.Systems
{
    public sealed class UpdateTransformScaleXToFaceAccordingMoveSystem : IProtoRunSystem
    {
        [DI] private readonly SpritesSharedAspect _ssAspect;
        [DI] private readonly MovingSharedAspect _mSharedAspect;
        [DI] private readonly SharedAspect _sAspect;
        
        public void Run()
        {
            foreach (var e in _ssAspect.MoveTransformFaces)
            {
                ref var fComponent = ref _ssAspect.FaceComponentPool.Get(e);
                ref var mComponent = ref _mSharedAspect.MoveComponentPool.Get(e);
                ref var tComponent = ref _sAspect.TransformComponentPool.Get(e);

                var scale = tComponent.Transform.localScale;
                scale.x = Mathf.Abs(scale.x);

                if (!SpritesSharedUtils.FacingDirectionMatchedWithMoveDirection(fComponent.Direction,
                        mComponent.Direction))
                {
                    scale.x *= -1f;
                }
                
                tComponent.Transform.localScale = scale;
            }
        }
    }
}