using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Monos
{
    public class Container : MonoBehaviour
    {
        public virtual Transform GetContainer() => transform;
    }
}