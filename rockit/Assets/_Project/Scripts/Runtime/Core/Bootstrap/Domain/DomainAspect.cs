using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Shared;
using _Project.Scripts.Runtime.Features.Input;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters;
using _Project.Scripts.Runtime.Features.Physics.Moving.Shared;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Callback;
using Leopotam.EcsProto.QoL;
using Leopotam.EcsProto.Unity.Physics2D;
using Leopotam.EcsProto.Unity.Ugui;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public class DomainAspect : ProtoAspectInject
    {
        public readonly UnityUguiAspect UguiAspect;
        public readonly UnityPhysics2DAspect Physics2DAspect;
        public readonly CallbackAspect CallbackAspect;
        public readonly InputAspect InputAspect;
        public readonly PhysicsSharedAspect PhysicsSharedAspect;
        public readonly CharactersMovingAspect CharactersMovingAspect;
        public readonly MovingSharedAspect MovingSharedAspect;
        public readonly AnimationsSharedAspect AnimationsSharedAspect;
        public readonly SpritesSharedAspect SpritesSharedAspect;
        public readonly SharedAspect SharedAspect;
    }
}