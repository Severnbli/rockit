using _Project.Scripts.Runtime.Features.Graphics.UI.Text.Shared.Components;
using _Project.Scripts.Runtime.Features.World.Levels.Components;
using _Project.Scripts.Runtime.Features.World.Levels.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.World.Levels
{
    public sealed class LevelsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<LevelItemComponent> LevelItemComponentPool;
        
        public readonly ProtoPool<TransformsStatsTag> TransformsStatsTagPool;
        public readonly ProtoIt TransformsStatsTextUis = new (It.Inc<TransformsStatsTag, TextUiComponent>());
        
        public readonly ProtoPool<StarsScoreStatsTag> StarsScoreStatsTagPool;
        public readonly ProtoIt StarsScoreStatsTextUis = new (It.Inc<StarsScoreStatsTag, TextUiComponent>());
    }
}