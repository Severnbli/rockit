using System;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Shared.Extensions.Shared
{
    public static class EcsExtensions
    {
        public static bool TryUnpackCompletely(this ProtoPackedEntityWithWorld packed, ProtoWorld world,
            out ProtoEntity entity)
        {
            return packed.TryUnpack(out var packedWorld, out entity) && packedWorld.Equals(world);
        }

        public static ProtoPool<T> GetPool<T>(this ProtoWorld world) where T : struct
        {
            return world.Pool<T>() as ProtoPool<T>;
        }

        public static void AddOrDelOnCondition<T>(this ProtoPool<T> pool, ProtoEntity entity, bool add) 
            where T : struct
        {
            if (add)
            {
                pool.GetOrAdd(entity);
            }
            else
            {
                pool.DelIfExists(entity);
            }
        }

        public static void AddOrDelOnCondition<T>(this ProtoPool<T> pool, ProtoEntity entity, Func<bool> add)
            where T : struct
        {
            AddOrDelOnCondition(pool, entity, add());
        }
    }
}