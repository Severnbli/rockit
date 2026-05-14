using _Project.Scripts.Runtime.Core.Infrastructure.Audio;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.Economy.Shared;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared;
using _Project.Scripts.Runtime.Features.Graphics.Platforms;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Shared;
using _Project.Scripts.Runtime.Features.Graphics.UI.Shared;
using _Project.Scripts.Runtime.Features.Input;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters;
using _Project.Scripts.Runtime.Features.Physics.Moving.Platforms;
using _Project.Scripts.Runtime.Features.Physics.Moving.Shared;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Features.Platforms.Shared;
using _Project.Scripts.Runtime.Features.Stats.Shared;
using _Project.Scripts.Runtime.Features.World.Shared;
using Leopotam.EcsProto.QoL;
using Leopotam.EcsProto.Unity.Physics2D;
using Leopotam.EcsProto.Unity.Ugui;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public sealed class DomainAspect : ProtoAspectInject
    {
        public readonly UnityUguiAspect UguiAspect;
        public readonly UnityPhysics2DAspect Physics2DAspect;
        public readonly InputAspect InputAspect;
        public readonly PhysicsSharedAspect PhysicsSharedAspect;
        public readonly PhysicsEventsAspect PhysicsEventsAspect;
        public readonly CharactersMovingAspect CharactersMovingAspect;
        public readonly MovingSharedAspect MovingSharedAspect;
        public readonly AnimationsSharedAspect AnimationsSharedAspect;
        public readonly SpritesSharedAspect SpritesSharedAspect;
        public readonly SpritesGlowAspect SpritesGlowAspect;
        public readonly PlatformsGraphicsAspect PlatformsGraphicsAspect;
        public readonly PlatformsMovingAspect PlatformsMovingAspect;
        public readonly PlatformsSharedAspect PlatformsSharedAspect;
        public readonly LocalizationAspect LocalizationAspect;
        public readonly UISharedAspect UISharedAspect;
        public readonly UIEventsAspect UIEventsAspect;
        public readonly LifecycleAspect LifecycleAspect;
        public readonly AudioAspect AudioAspect;
        public readonly WorldSharedAspect WorldSharedAspect;
        public readonly ScenesAspect ScenesAspect;
        public readonly EconomySharedAspect EconomySharedAspect;
        public readonly StatsSharedAspect StatsSharedAspect;
        public readonly SharedAspect SharedAspect;
    }
}