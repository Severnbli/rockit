using _Project.Scripts.Runtime.Features.Graphics.Particles.Types;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Particles.Systems
{
    public sealed class DespawnRotationPlatformParticleSystemOnNotAliveSystem : IProtoRunSystem
    {
        [DI] private readonly ParticlesAspect _pAspect;
        private readonly RotationPlatformParticleSystemPool _rppsPool;

        public DespawnRotationPlatformParticleSystemOnNotAliveSystem(RotationPlatformParticleSystemPool rppsPool)
        {
            _rppsPool = rppsPool;
        }

        public void Run()
        {
            foreach (var e in _pAspect.ActiveRotationPlatformParticleSystems)
            {
                ref var psComponent = ref _pAspect.ParticleSystemComponentPool.Get(e);
                if (psComponent.ParticleSystem.IsAlive()) continue;
                
                _rppsPool.Despawn(psComponent.ParticleSystem);
            }
        }
    }
}