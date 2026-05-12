using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Tags;
using _Project.Scripts.Runtime.Features.World.Levels.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.World.Levels
{
    public sealed class LevelsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<LevelItemComponent> LevelItemComponentPool;
        public readonly ProtoIt LevelItemOpeners = new (It.Inc<LevelItemComponent, OpenerTag>());
    }
}