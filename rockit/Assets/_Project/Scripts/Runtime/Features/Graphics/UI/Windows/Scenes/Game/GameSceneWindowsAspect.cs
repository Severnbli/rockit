using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game
{
    public sealed class GameSceneWindowsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<PauseTag> PauseTagPool;
    }
}