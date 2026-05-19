using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Project.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Project
{
    public sealed class ProjectWindowsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<ControlsWindowTag> ControlsWindowTagPool;
    }
}