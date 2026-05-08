using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Sfx.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Shared.Monos;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Shared.Types;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Sfx.Types
{
    public class SfxAudioSourcePool : AudioSourcePool<SfxAudioSourcePoolSpawnSettings, SfxAudioSourcePoolDespawnSettings>
    {
        private readonly SfxConfig _sfxConfig;
        
        public SfxAudioSourcePool(SfxConfig sfxConfig, AudioSourceContainer asContainer, ProtoWorld world) : 
            base(asContainer, world)
        {
            _sfxConfig = sfxConfig;
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