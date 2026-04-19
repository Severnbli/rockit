using System.Collections.Generic;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class SharedExtensions
    {
        public static bool TryGetEntityFromIndex(this Dictionary<GameObject, ProtoPackedEntityWithWorld> index,
            GameObject go, ProtoWorld world, out ProtoEntity entity)
        {
            entity = default;

            return index.TryGetValue(go, out var packed) && packed.TryUnpackCompletely(world, out entity);
        }
    }
}