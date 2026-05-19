using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools;
using _Project.Scripts.Runtime.Features.Graphics.Particles.Monos;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Particles.Types
{
    public abstract class ParticleSystemPool : BasePrefabPool<ParticleSystem, ParticleSystemPoolSpawnSettings, ParticleSystemPoolDespawnSettings>
    {
        protected readonly ParticleSystemsContainer PsContainer;
        
        protected ParticleSystemPool(ProtoWorld world, ParticleSystemsContainer psContainer) : base(world)
        {
            PsContainer = psContainer;
        }
    }

    public struct ParticleSystemPoolSpawnSettings
    {
        public Vector2 At;
    }

    public struct ParticleSystemPoolDespawnSettings
    {
        
    }
}