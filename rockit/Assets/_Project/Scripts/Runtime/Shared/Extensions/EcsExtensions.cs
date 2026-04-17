using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class EcsExtensions
    {
        public static bool FromExactWorld(this ProtoPackedEntityWithWorld packed, ProtoWorld world)
        {
            return packed.World.Equals(world);
        }
    }
}