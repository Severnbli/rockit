using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Graphics.Particles;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Systems
{
    public sealed class StopPlatformsAreaParticleSystemOnPlatformsAreaServiceDisabledRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly PlatformsSharedRequestsAspect _psrAspect;
        [DI] private readonly PlatformsSharedAspect _psAspect;
        [DI] private readonly ParticlesAspect _pAspect;
        
        public void Run()
        {
            if (_psrAspect.PlatformsAreaServiceDisabledRequests.IsEmptySlow()) return;

            foreach (var e in _psAspect.PlatformsAreaParticleSystems)
            {
                ref var psComponent = ref _pAspect.ParticleSystemComponentPool.Get(e);
                psComponent.ParticleSystem.Stop();
            }
        }
    }
}