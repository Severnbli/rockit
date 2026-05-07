using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs
{
    public class MusicConfig : ScriptableObjectAutoInstaller<MusicConfig>
    {
        [SerializeField] private AudioClip _menu;
        [SerializeField] private AudioClip _game;
        
        public AudioClip Menu => _menu;
        public AudioClip Game => _game;
    }
}