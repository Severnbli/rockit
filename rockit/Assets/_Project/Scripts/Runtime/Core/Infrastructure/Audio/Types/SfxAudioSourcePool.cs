using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Monos;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Types
{
    public class SfxAudioSourcePool : AudioSourcePool<SfxAudioSourcePoolSpawnSettings, SfxAudioSourcePoolDespawnSettings>
    {
        private readonly SfxConfig _sfxConfig;
        
        public SfxAudioSourcePool(SfxConfig sfxConfig, AudioSourceContainer asContainer, ProtoWorld world) : 
            base(asContainer, world)
        {
            _sfxConfig = sfxConfig;
        }

        protected override void PostSpawn(AudioSource instance, Transform at = null, SfxAudioSourcePoolSpawnSettings settings = default)
        {
            base.PostSpawn(instance, at, settings);
            
            if (settings.Clip != null) instance.PlayOneShot(settings.Clip);
        }

        protected override GameObject GetPrefab() => _sfxConfig.AudioSourcePrefab;
    }
    
    public struct SfxAudioSourcePoolSpawnSettings
    {
        public AudioClip Clip;
    }
    
    public struct SfxAudioSourcePoolDespawnSettings
    {
        
    }
}