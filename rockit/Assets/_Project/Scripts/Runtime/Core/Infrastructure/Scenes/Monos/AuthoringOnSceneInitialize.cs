using Leopotam.EcsProto.Unity;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Monos
{
    public class AuthoringOnSceneInitialize : MonoInitializableOnSceneInitialize
    {
        [SerializeField] private ProtoUnityAuthoring _authoring;
        
        public override void Initialize()
        {
            _authoring.ProcessAuthoring();
        }
    }
}