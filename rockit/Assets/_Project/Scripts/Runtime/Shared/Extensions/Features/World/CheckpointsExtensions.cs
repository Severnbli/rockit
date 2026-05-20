using _Project.Scripts.Runtime.Features.World.Checkpoints.Services;
using _Project.Scripts.Runtime.Features.World.Checkpoints.Tags;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Shared.Extensions.Features.World
{
    public static class CheckpointsExtensions
    {
        public static void ExpireLast(this CheckpointsService cService)
        {
            if (cService.LastCheckpoint == null) return;

            var packed = cService.LastCheckpoint.Authoring.Entity();
            packed.TryUnpack(out var world, out var e);

            var pool = world.Pool<ActiveCheckpointTag>();
            if (pool.Has(e)) pool.Del(e);
        }
    }
}