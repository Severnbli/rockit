using _Project.Scripts.Runtime.Features.Graphics.Particles.Types;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Particles.Systems
{
    public sealed class DespawnPositionPlatformParticleSystemOnNotAliveSystem : IProtoRunSystem
    {
        [DI] private readonly ParticlesAspect _pAspect;
        private readonly PositionPlatformParticleSystemPool _pppsPool;

        public DespawnPositionPlatformParticleSystemOnNotAliveSystem(PositionPlatformParticleSystemPool pppsPool)
        {
            _pppsPool = pppsPool;
        }

        public void Run()
        {
            foreach (var e in _pAspect.ActivePositionPlatformParticleSystems)
            {
                ref var psComponent = ref _pAspect.ParticleSystemComponentPool.Get(e);
                if (psComponent.ParticleSystem.IsAlive()) continue;
                
                _pppsPool.Despawn(psComponent.ParticleSystem);
            }
        }
    }
}