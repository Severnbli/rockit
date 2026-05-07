using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories
{
    public interface IPrefabFactory<out TItem, in TSetting> 
        where TItem : Component 
        where TSetting : struct
    {
        TItem Create(Transform at = null, TSetting settings = default);
    }
}