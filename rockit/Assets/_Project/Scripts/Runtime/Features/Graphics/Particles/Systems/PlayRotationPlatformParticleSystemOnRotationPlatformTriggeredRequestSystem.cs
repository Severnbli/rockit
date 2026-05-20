using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.Graphics.Particles.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Particles.Types;
using _Project.Scripts.Runtime.Features.Platforms.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Particles.Systems
{
    public sealed class PlayRotationPlatformParticleSystemOnRotationPlatformTriggeredRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly PlatformsSharedRequestsAspect _psrAspect;
        [DI] private readonly SharedAspect _sAspect;
        private readonly RotationPlatformParticleSystemPool _rppsPool;
        private readonly PlatformParticlesConfig _ppConfig;

        public PlayRotationPlatformParticleSystemOnRotationPlatformTriggeredRequestSystem(RotationPlatformParticleSystemPool rppsPool, PlatformParticlesConfig ppConfig)
        {
            _rppsPool = rppsPool;
            _ppConfig = ppConfig;
        }

        public void Run()
        {
            if (_psrAspect.RotationPlatformTriggeredRequests.IsEmptySlow()) return;

            foreach (var e in _sAspect.TransformPlayers)
            {
                ref var tComponent = ref _sAspect.TransformComponentPool.Get(e);

                var settings = new ParticleSystemPoolSpawnSettings
                {
                    At = (Vector2) tComponent.Transform.position + _ppConfig.PlayerOffset
                };
                _rppsPool.Spawn(settings: settings);
            }
        }
    }
}