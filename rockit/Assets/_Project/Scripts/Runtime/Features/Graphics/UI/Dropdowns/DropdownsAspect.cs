using _Project.Scripts.Runtime.Features.Graphics.UI.Dropdowns.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Dropdowns
{
    public sealed class DropdownsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<DropdownComponent> DropdownComponentPool;
    }
}