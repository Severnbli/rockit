using System.Collections.Generic;
using _Project.Scripts.Runtime.Shared.Extensions;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Monos
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private GameObject _positionStates;
        [SerializeField] private GameObject _rotationStates;
        [SerializeField] private GameObject _scaleStates;

        public IEnumerable<Transform> PositionStates => _positionStates.GetChildrenComponents<Transform>();
        public IEnumerable<Transform> RotationStates => _rotationStates.GetChildrenComponents<Transform>();
        public IEnumerable<Transform> ScaleStates => _scaleStates.GetChildrenComponents<Transform>();
    }
}