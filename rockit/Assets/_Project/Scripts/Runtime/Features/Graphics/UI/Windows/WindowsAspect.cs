using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows
{
    public sealed class WindowsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<LevelSelectionTag> LevelSelectionTagPool;
    }
}