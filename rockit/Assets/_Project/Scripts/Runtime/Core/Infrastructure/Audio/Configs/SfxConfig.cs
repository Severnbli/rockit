using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs
{
    public sealed class SfxConfig : AudioConfig<SfxConfig>
    {
        [SerializeField] private AudioClip _clickClip;
        
        public AudioClip ClickClip => _clickClip;
    }
}