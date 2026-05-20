using _Project.Scripts.Runtime.Features.Graphics.Particles.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Particles.Monos;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Particles.Types
{
    public sealed class RotationPlatformParticleSystemPool : ParticleSystemPool
    {
        private readonly PlatformParticlesConfig _ppConfig;
        
        public RotationPlatformParticleSystemPool(ProtoWorld world, ParticleSystemsContainer psContainer, 
            PlatformParticlesConfig ppConfig) : base(world, psContainer)
        {
            _ppConfig = ppConfig;
        }

        protected override GameObject GetPrefab() => _ppConfig.RotationPrefab;
    }
}