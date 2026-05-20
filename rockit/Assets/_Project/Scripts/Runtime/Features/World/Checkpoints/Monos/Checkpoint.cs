using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Monos;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.World.Checkpoints.Monos
{
    public class Checkpoint : AuthoringLinkable
    {
        [SerializeField] private GameObject _checkLocation;
        
        public Vector2 GetCheckLocation() => _checkLocation.transform.position;
    }
}