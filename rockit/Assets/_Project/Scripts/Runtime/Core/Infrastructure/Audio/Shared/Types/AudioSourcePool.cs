using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Shared.Monos;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Shared.Types
{
    public abstract class AudioSourcePool<TSpawnSettings, TDespawnSettings> : BasePrefabPool<AudioSource, TSpawnSettings, TDespawnSettings> 
        where TSpawnSettings : struct 
        where TDespawnSettings : struct
    {
        private readonly AudioSourceContainer _asContainer;

        protected AudioSourcePool(AudioSourceContainer asContainer)
        {
            _asContainer = asContainer;
        }

        protected override void PostCreate(AudioSource instance, TSpawnSettings settings = default)
        {
            base.PostCreate(instance, settings);
            
            instance.playOnAwake = false;
            instance.loop = false;
        }

        protected override void PostDespawn(AudioSource instance, TDespawnSettings settings = default)
        {
            base.PostDespawn(instance, settings);
            
            instance.Stop();
            instance.clip = null;
        }

        protected override Transform FallbackContainer() => _asContainer.transform;
    }
}