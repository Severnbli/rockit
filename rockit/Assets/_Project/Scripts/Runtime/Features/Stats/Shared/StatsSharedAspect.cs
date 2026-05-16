using _Project.Scripts.Runtime.Features.Graphics.UI.Text.Shared.Components;
using _Project.Scripts.Runtime.Features.Stats.Constants;
using _Project.Scripts.Runtime.Features.Stats.Shared.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Stats.Shared
{
    public sealed class StatsSharedAspect : ProtoAspectInject
    {
        public readonly ConstantsAspect ConstantsAspect;
        
        public readonly ProtoPool<StarsTotalizerTag> StarsTotalizerTagPool;
        public readonly ProtoIt StarsTotalizerTextUis = new (It.Inc<StarsTotalizerTag, TextUiComponent>());
    }
}