using System;
using _Project.Scripts.Runtime.Features.World.Checkpoints.Monos;
using Leopotam.EcsProto.Unity;

namespace _Project.Scripts.Runtime.Features.World.Checkpoints.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct CheckpointComponent
    {
        public Checkpoint Checkpoint;
    }
}