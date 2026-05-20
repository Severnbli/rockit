using _Project.Scripts.Runtime.Features.World.Checkpoints.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.World.Checkpoints
{
    public sealed class CheckpointsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<CheckpointComponent> CheckpointComponentPool;
    }
}