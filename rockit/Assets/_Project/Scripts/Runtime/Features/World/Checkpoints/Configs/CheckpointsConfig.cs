using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.World.Checkpoints.Configs
{
    public sealed class CheckpointsConfig : ScriptableObjectAutoInstaller<CheckpointsConfig>
    {
        [SerializeField] private float _checkDistance = 0.5f;
        
        public float CheckDistance => _checkDistance;
    }
}