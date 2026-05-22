using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Configs
{
    public sealed class PlatformsAreaConfig : ScriptableObjectAutoInstaller<PlatformsAreaConfig>
    {
        [SerializeField] private float _radius = 4f;
        [SerializeField] private Vector2 _playerOffset = new (0f, 1.5f);
        
        public float Radius => _radius;
        public Vector2 PlayerOffset => _playerOffset;
    }
}