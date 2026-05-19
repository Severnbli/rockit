using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Particles.Types
{
    public abstract class ParticleSystemPool : BasePrefabPool<ParticleSystem, ParticleSystemPoolSpawnSettings, ParticleSystemPoolDespawnSettings>
    {
        protected ParticleSystemPool(ProtoWorld world) : base(world)
        {
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