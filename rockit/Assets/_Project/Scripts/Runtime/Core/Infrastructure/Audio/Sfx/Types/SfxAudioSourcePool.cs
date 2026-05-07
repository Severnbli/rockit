using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Sfx.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Shared.Monos;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Shared.Types;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Sfx.Types
{
    public class SfxAudioSourcePool : AudioSourcePool
    {
        private readonly SfxConfig _sfxConfig;
        
        public SfxAudioSourcePool(SfxConfig sfxConfig, AudioSourceContainer asContainer) : base(asContainer)
        {
            _sfxConfig = sfxConfig;
        }

        protected override GameObject GetPrefab() => _sfxConfig.AudioSourcePrefab;
    }
}