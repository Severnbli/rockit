using _Project.Scripts.Runtime.Features.Platforms.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared
{
    public class PlatformsSharedAspect : ProtoAspectInject
    {
        public readonly ProtoPool<PlatformComponent> PlatformComponentPool;
        public readonly ProtoIt Platforms = new (It.Inc<PlatformComponent>());
    }
}