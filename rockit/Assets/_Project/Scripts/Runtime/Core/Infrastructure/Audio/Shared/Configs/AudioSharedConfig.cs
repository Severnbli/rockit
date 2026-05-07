using _Project.Scripts.Modules.Zenject;
using UnityEngine;
using UnityEngine.Audio;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Shared.Configs
{
    public class AudioSharedConfig : ScriptableObjectAutoInstaller<AudioSharedConfig>
    {
        [SerializeField] private AudioMixer _audioMixer;
        
        public AudioMixer AudioMixer => _audioMixer;
    }
}