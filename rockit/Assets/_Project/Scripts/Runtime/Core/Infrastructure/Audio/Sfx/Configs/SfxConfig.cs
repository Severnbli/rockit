using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Sfx.Configs
{
    public class SfxConfig : ScriptableObjectAutoInstaller<SfxConfig>
    {
        [SerializeField] private GameObject _audioSourcePrefab;
        
        public GameObject AudioSourcePrefab => _audioSourcePrefab;
    }
}