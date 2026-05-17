using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Types;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Monos
{
    public abstract class MonoInitializableOnSceneInitialize : MonoBehaviour, IInitializableOnSceneInitialize
    {
        public abstract void Initialize();
    }
}