using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs
{
    public class AudioConfig<T> : ScriptableObjectAutoInstaller<T> where T : AudioConfig<T> 
    {
        [SerializeField] private GameObject _audioSourcePrefab;
        
        public GameObject AudioSourcePrefab => _audioSourcePrefab;
    }
}