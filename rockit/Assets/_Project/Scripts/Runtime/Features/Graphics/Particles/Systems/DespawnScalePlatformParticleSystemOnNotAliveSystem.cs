using _Project.Scripts.Runtime.Features.Graphics.Particles.Types;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Particles.Systems
{
    public sealed class DespawnScalePlatformParticleSystemOnNotAliveSystem : IProtoRunSystem
    {
        [DI] private readonly ParticlesAspect _pAspect;
        private readonly ScalePlatformParticleSystemPool _sppsPool;

        public DespawnScalePlatformParticleSystemOnNotAliveSystem(ScalePlatformParticleSystemPool sppsPool)
        {
            _sppsPool = sppsPool;
        }

        public void Run()
        {
            foreach (var e in _pAspect.ActiveScalePlatformParticleSystems)
            {
                ref var psComponent = ref _pAspect.ParticleSystemComponentPool.Get(e);
                if (psComponent.ParticleSystem.IsAlive()) continue;
                
                _sppsPool.Despawn(psComponent.ParticleSystem);
            }
        }
    }
}