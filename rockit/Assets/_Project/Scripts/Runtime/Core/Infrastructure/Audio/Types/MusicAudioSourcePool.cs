using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Monos;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Types
{
    public class MusicAudioSourcePool : AudioSourcePool<MusicAudioSourcePoolSpawnSettings, MusicAudioSourcePoolDespawnSettings>
    {
        private readonly MusicConfig _mConfig;

        public MusicAudioSourcePool(MusicConfig mConfig, AudioSourceContainer asContainer, ProtoWorld world) : 
            base(asContainer, world)
        {
            _mConfig = mConfig;
        }

        protected override GameObject GetPrefab() => _mConfig.AudioSourcePrefab;
    }

    public struct MusicAudioSourcePoolSpawnSettings
    {
        
    }
    
    public struct MusicAudioSourcePoolDespawnSettings
    {
        
    }
}