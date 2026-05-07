using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Shared.Monos;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Shared.Types
{
    public abstract class AudioSourcePool : BasePrefabPool<AudioSource>
    {
        private readonly AudioSourceContainer _asContainer;

        protected AudioSourcePool(AudioSourceContainer asContainer)
        {
            _asContainer = asContainer;
        }

        protected override void PostCreate(AudioSource instance)
        {
            base.PostCreate(instance);
            
            instance.playOnAwake = false;
            instance.loop = false;
        }

        protected override void PostDespawn(AudioSource instance)
        {
            base.PostDespawn(instance);
            
            instance.Stop();
            instance.clip = null;
        }

        protected override Transform FallbackContainer() => _asContainer.transform;
    }
}