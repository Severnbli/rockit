using System.Collections.Generic;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Enums;
using _Project.Scripts.Runtime.Shared.Extensions;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Monos
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private GameObject _positionStates;
        [SerializeField] private GameObject _rotationStates;
        [SerializeField] private GameObject _scaleStates;
        [SerializeField] private PlatformType[] _types;

        public List<Transform> PositionStates => _positionStates.GetChildrenComponents<Transform>();
        public List<Transform> RotationStates => _rotationStates.GetChildrenComponents<Transform>();
        public List<Transform> ScaleStates => _scaleStates.GetChildrenComponents<Transform>();
        public PlatformType[] Types => _types;
    }
}