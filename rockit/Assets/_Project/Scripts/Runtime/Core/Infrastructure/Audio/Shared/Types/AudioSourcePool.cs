using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Shared.Types
{
    public abstract class AudioSourcePool : BasePrefabPool<AudioSource>
    {
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
    }
}