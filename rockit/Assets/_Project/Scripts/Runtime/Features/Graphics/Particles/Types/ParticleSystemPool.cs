using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools;
using _Project.Scripts.Runtime.Features.Graphics.Particles.Monos;
using _Project.Scripts.Runtime.Shared.Extensions.Shared;
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

        protected override void PostSpawn(ParticleSystem instance, Transform at = null, ParticleSystemPoolSpawnSettings settings = default)
        {
            base.PostSpawn(instance, at, settings);
            
            instance.transform.PlaceTo(settings.At);
            instance.Play();
        }

        protected override Transform FallbackContainer() => PsContainer.GetContainer();
    }

    public struct ParticleSystemPoolSpawnSettings
    {
        public Vector2 At;
    }

    public struct ParticleSystemPoolDespawnSettings
    {
        
    }
}