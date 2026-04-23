using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization
{
    public sealed class LocalizationAspect : ProtoAspectInject
    {
        public readonly ProtoPool<LocalizationItemComponent> LocalizationItemComponentPool;
        public readonly ProtoIt LocalizationItems = new (It.Inc<LocalizationItemComponent>());
    }
}