using _Project.Scripts.Runtime.Features.Graphics.Particles;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Services;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Systems
{
    public sealed class UpdatePlatformsAreaParticleSystemRadiusOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly PlatformsSharedAspect _psAspect;
        [DI] private readonly ParticlesAspect _pAspect;
        private readonly PlatformsAreaService _paService;
        
        public void Run()
        {
            if (!_paService.Enabled) return;
            
            foreach (var e in _psAspect.PlatformsAreaParticleSystems)
            {
                ref var psComponent = ref _pAspect.ParticleSystemComponentPool.Get(e);
                var shape = psComponent.ParticleSystem.shape;
                shape.radius = _paService.Radius;
            }
        }
    }
}