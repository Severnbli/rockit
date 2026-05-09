using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters;
using _Project.Scripts.Runtime.Shared.Utils.Features.Graphics.Sprites;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Sprites.Shared.Systems
{
    public sealed class UpdateTransformScaleXToFaceAccordingCharacterMoveSystem : IProtoRunSystem
    {
        [DI] private readonly SpritesSharedAspect _ssAspect;
        [DI] private readonly CharactersMovingAspect _cmAspect;
        [DI] private readonly SharedAspect _sAspect;
        
        public void Run()
        {
            foreach (var e in _ssAspect.CharacterMoveTransformFaces)
            {
                ref var fComponent = ref _ssAspect.FaceComponentPool.Get(e);
                ref var cmComponent = ref _cmAspect.CharacterMoveComponentPool.Get(e);
                ref var tComponent = ref _sAspect.TransformComponentPool.Get(e);

                var scale = tComponent.Transform.localScale;
                scale.x = Mathf.Abs(scale.x);

                if (!SpritesSharedUtils.FacingDirectionMatchedWithMoveDirection(fComponent.Direction,
                        cmComponent.Direction))
                {
                    scale.x *= -1f;
                }
                
                tComponent.Transform.localScale = scale;
            }
        }
    }
}