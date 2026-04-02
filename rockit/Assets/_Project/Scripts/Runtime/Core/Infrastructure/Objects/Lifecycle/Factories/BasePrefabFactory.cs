using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories
{
    public class BasePrefabFactory<T> : BaseFactory<T> where T : MonoBehaviour
    {
        protected override T CreateInstance()
        {
            var emptyGameObject = new GameObject();
            return emptyGameObject.AddComponent<T>();
        }

        public virtual GameObject GetPrefab()
        {
            return new GameObject();
        }
    }
}