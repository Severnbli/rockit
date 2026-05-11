using _Project.Scripts.Runtime.Features.World.Levels;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.World.Shared
{
    public sealed class WorldSharedAspect : ProtoAspectInject
    {
        public readonly LevelsAspect LevelsAspect;
    }
}