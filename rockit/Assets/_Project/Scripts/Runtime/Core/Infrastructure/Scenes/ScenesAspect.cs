using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes
{
    public sealed class ScenesAspect : ProtoAspectInject
    {
        public readonly ProtoPool<MenuSceneTag> MenuSceneTagPool;
    }
}