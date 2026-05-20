using UnityEngine;

namespace _Project.Scripts.Runtime.Features.World.Checkpoints.Monos
{
    public class Checkpoint : MonoBehaviour
    {
        [SerializeField] private GameObject _checkLocation;
        
        public Vector2 GetCheckLocation() => _checkLocation.transform.position;
    }
}