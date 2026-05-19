using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Platforms.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Particles.Systems
{
    public sealed class PlayRotationPlatformParticleSystemOnRotationPlatformTriggeredRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly PlatformsSharedRequestsAspect _psrAspect;
        [DI] private readonly ParticlesAspect _pAspect;
        
        public void Run()
        {
            if (_psrAspect.RotationPlatformTriggeredRequests.IsEmptySlow()) return;

            foreach (var e in _pAspect.RotationPlatformParticleSystems)
            {
                ref var psComponent = ref _pAspect.ParticleSystemComponentPool.Get(e);
                psComponent.ParticleSystem.Play();
            }
        }
    }
}