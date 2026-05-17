using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Types;
using Leopotam.EcsProto.Unity;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Monos
{
    public class AuthoringOnSceneInitialize : MonoBehaviour, IInitializableOnSceneInitialize
    {
        [SerializeField] private ProtoUnityAuthoring _authoring;
        
        public void Initialize()
        {
            _authoring.ProcessAuthoring();
        }
    }
}