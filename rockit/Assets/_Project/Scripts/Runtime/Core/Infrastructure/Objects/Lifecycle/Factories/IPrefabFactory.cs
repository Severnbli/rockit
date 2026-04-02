using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories
{
    public interface IPrefabFactory<out T> where T : Component
    {
        T Create(Transform at = null);
    }
}