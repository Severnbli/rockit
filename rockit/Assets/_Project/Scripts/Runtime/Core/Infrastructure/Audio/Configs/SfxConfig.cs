using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs
{
    public sealed class SfxConfig : AudioConfig<SfxConfig>
    {
        [SerializeField] private AudioClip _buttonClip;
        
        public AudioClip ButtonClip => _buttonClip;
    }
}