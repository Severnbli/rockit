using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories
{
    public interface IPrefabFactory<out TItem> where TItem : Component
    {
        TItem Create(Transform at = null);
    }
}