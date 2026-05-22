using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Graphics.Particles;
using _Project.Scripts.Runtime.Features.World.Levels;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Systems
{
    public sealed class PlayPlatformsAreaParticleSystemOnPlatformsAreaServiceEnabledRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly PlatformsSharedRequestsAspect _psrAspect;
        [DI] private readonly PlatformsSharedAspect _psAspect;
        [DI] private readonly ParticlesAspect _pAspect;
        
        public void Run()
        {
            if (_psrAspect.PlatformsAreaServiceEnabledRequests.IsEmptySlow()) return;

            foreach (var e in _psAspect.PlatformsAreaParticleSystems)
            {
                ref var psComponent = ref _pAspect.ParticleSystemComponentPool.Get(e);
                psComponent.ParticleSystem.Play();
            }
        }
    }
}