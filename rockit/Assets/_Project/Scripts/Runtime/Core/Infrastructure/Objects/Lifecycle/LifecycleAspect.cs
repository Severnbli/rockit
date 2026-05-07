using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle
{
    public sealed class LifecycleAspect : ProtoAspectInject
    {
        public ProtoPool<CreatedAtFactoryTag> CreatedAtFactoryTagPool;
        public ProtoIt CreatedAtFactoryTags = new (It.Inc<CreatedAtFactoryTag>());
    }
}