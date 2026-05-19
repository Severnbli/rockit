using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Platforms.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Particles.Systems
{
    public sealed class PlayPositionPlatformParticleSystemOnPositionPlatformTriggeredRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly PlatformsSharedRequestsAspect _psrAspect;
        [DI] private readonly ParticlesAspect _pAspect;
        
        public void Run()
        {
            if (_psrAspect.PositionPlatformTriggeredRequests.IsEmptySlow()) return;

            foreach (var e in _pAspect.PositionPlatformParticleSystems)
            {
                ref var psComponent = ref _pAspect.ParticleSystemComponentPool.Get(e);
                psComponent.ParticleSystem.Play();
            }
        }
    }
}