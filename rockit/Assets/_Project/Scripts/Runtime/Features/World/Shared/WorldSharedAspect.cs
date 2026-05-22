using _Project.Scripts.Runtime.Features.World.Checkpoints;
using _Project.Scripts.Runtime.Features.World.Levels;
using _Project.Scripts.Runtime.Features.World.Teleporters;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.World.Shared
{
    public sealed class WorldSharedAspect : ProtoAspectInject
    {
        public readonly LevelsAspect LevelsAspect;
        public readonly CheckpointsAspect CheckpointsAspect;
        public readonly TeleportersAspect TeleportersAspect;
    }
}