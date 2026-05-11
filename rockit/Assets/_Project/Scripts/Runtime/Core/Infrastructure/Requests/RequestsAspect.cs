using _Project.Scripts.Runtime.Core.Infrastructure.Audio;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Characters;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow;
using _Project.Scripts.Runtime.Features.Graphics.UI.Shared;
using _Project.Scripts.Runtime.Features.Input;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters;
using _Project.Scripts.Runtime.Features.Physics.Moving.Platforms;
using _Project.Scripts.Runtime.Features.Stats.Player;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests
{
    public sealed class RequestsAspect : ProtoAspectInject
    {
        public readonly CoreRequestsAspect CoreRequestsAspect;
        public readonly InputRequestsAspect InputRequestsAspect;
        public readonly CharactersMovingRequestsAspect CharactersMovingRequestsAspect;
        public readonly CharactersAnimationsRequestsAspect CharactersAnimationsRequestsAspect;
        public readonly PlatformsMovingRequestsAspect PlatformsMovingRequestsAspect;
        public readonly LocalizationRequestsAspect LocalizationRequestsAspect;
        public readonly StorageRequestsAspect StorageRequestsAspect;
        public readonly ScenesRequestsAspect ScenesRequestsAspect;
        public readonly PlayerStatsRequestsAspect PlayerStatsRequestsAspect;
        public readonly AudioRequestsAspect AudioRequestsAspect;
        public readonly SpritesGlowRequestsAspect SpritesGlowRequestsAspect;
        public readonly UIRequestsAspect UIRequestsAspect;
        public readonly SharedRequestsAspect SharedRequestsAspect;
    }
}