using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Tags;
using _Project.Scripts.Runtime.Features.Graphics.UI.Dropdowns.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Dropdowns
{
    public sealed class DropdownsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<DropdownComponent> DropdownComponentPool;
        public readonly ProtoIt DropdownLocalizationSelectors = new (It.Inc<DropdownComponent, LocalizationSelectorTag>());
    }
}