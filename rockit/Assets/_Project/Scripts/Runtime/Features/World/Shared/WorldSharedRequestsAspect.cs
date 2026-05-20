using _Project.Scripts.Runtime.Features.World.Checkpoints;
using _Project.Scripts.Runtime.Features.World.Levels;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.World.Shared
{
    public sealed class WorldSharedRequestsAspect : ProtoAspectInject
    {
        public readonly LevelsRequestsAspect LevelsRequestsAspect;
        public readonly CheckpointsRequestsAspect CheckpointsRequestsAspect;
    }
}