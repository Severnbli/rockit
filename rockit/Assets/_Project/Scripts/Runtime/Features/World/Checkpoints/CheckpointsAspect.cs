using _Project.Scripts.Runtime.Features.World.Checkpoints.Components;
using _Project.Scripts.Runtime.Features.World.Checkpoints.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.World.Checkpoints
{
    public sealed class CheckpointsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<CheckpointComponent> CheckpointComponentPool;
        public readonly ProtoPool<ActiveCheckpointTag> ActiveCheckpointTagPool;
    }
}