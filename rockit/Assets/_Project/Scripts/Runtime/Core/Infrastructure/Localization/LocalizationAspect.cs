using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization
{
    public sealed class LocalizationAspect : ProtoAspectInject
    {
        public readonly ProtoPool<LocalizationItemComponent> LocalizationItemComponentPool;
        public readonly ProtoPool<LocalizationSelectorTag> LocalizationSelectorTagPool;
        public readonly ProtoIt LocalizationItems = new (It.Inc<LocalizationItemComponent>());
    }
}