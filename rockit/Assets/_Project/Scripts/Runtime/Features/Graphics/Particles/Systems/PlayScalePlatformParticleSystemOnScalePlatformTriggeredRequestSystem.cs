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
    public sealed class PlayScalePlatformParticleSystemOnScalePlatformTriggeredRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly PlatformsSharedRequestsAspect _psrAspect;
        [DI] private readonly SharedAspect _sAspect;
        private readonly ScalePlatformParticleSystemPool _sppsPool;
        private readonly PlatformParticlesConfig _ppConfig;

        public PlayScalePlatformParticleSystemOnScalePlatformTriggeredRequestSystem(ScalePlatformParticleSystemPool sppsPool, PlatformParticlesConfig ppConfig)
        {
            _sppsPool = sppsPool;
            _ppConfig = ppConfig;
        }

        public void Run()
        {
            if (_psrAspect.ScalePlatformTriggeredRequests.IsEmptySlow()) return;

            foreach (var e in _sAspect.TransformPlayers)
            {
                ref var tComponent = ref _sAspect.TransformComponentPool.Get(e);

                var settings = new ParticleSystemPoolSpawnSettings
                {
                    At = (Vector2) tComponent.Transform.position + _ppConfig.PlayerOffset
                };
                _sppsPool.Spawn(settings: settings);
            }
        }
    }
}