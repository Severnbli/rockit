using Leopotam.EcsProto.Unity;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Monos
{
    public class AuthoringLinkable : MonoBehaviour
    {
        [SerializeField] private ProtoUnityAuthoring _authoring;
        
        public ProtoUnityAuthoring Authoring => _authoring;
    }
}