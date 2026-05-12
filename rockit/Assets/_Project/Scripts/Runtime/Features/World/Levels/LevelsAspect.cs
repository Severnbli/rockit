using _Project.Scripts.Runtime.Features.World.Levels.Components;
using _Project.Scripts.Runtime.Features.World.Levels.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.World.Levels
{
    public sealed class LevelsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<LevelItemComponent> LevelItemComponentPool;
        public readonly ProtoPool<LevelLoaderTag> LevelLoaderTagPool;
    }
}