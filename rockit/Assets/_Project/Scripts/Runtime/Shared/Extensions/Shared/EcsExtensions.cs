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
    }
}