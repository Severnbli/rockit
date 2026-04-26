using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using Leopotam.EcsProto.Unity.Ugui;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared
{
    public sealed class UIEventsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<UnityUguiClickEvent> ClickEvent;
        public readonly ProtoPool<UnityUguiDownEvent> DownEvent;
        public readonly ProtoPool<UnityUguiDragEndEvent> DragEndEvent;
        public readonly ProtoPool<UnityUguiDragMoveEvent> DragMoveEvent;
        public readonly ProtoPool<UnityUguiDragStartEvent> DragStartEvent;
        public readonly ProtoPool<UnityUguiDropEvent> DropEvent;
        public readonly ProtoPool<UnityUguiEnterEvent> EnterEvent;
        public readonly ProtoPool<UnityUguiExitEvent> ExitEvent;
        public readonly ProtoPool<UnityUguiScrollViewEvent> ScrollViewEvent;
        public readonly ProtoPool<UnityUguiSliderChangeEvent> SliderChangeEvent;
        public readonly ProtoPool<UnityUguiDropdownChangeEvent> DropdownChangeEvent;
        public readonly ProtoPool<UnityUguiInputChangeEvent> InputChangeEvent;
        public readonly ProtoPool<UnityUguiInputEndEvent> InputEndEvent;
        public readonly ProtoPool<UnityUguiUpEvent> UpEvent;

        public readonly ProtoIt ClickEvents = new(It.Inc<UnityUguiClickEvent>());
        public readonly ProtoIt DownEvents = new(It.Inc<UnityUguiDownEvent>());
        public readonly ProtoIt DragEndEvents = new(It.Inc<UnityUguiDragEndEvent>());
        public readonly ProtoIt DragMoveEvents = new(It.Inc<UnityUguiDragMoveEvent>());
        public readonly ProtoIt DragStartEvents = new(It.Inc<UnityUguiDragStartEvent>());
        public readonly ProtoIt DropEvents = new(It.Inc<UnityUguiDropEvent>());
        public readonly ProtoIt EnterEvents = new(It.Inc<UnityUguiEnterEvent>());
        public readonly ProtoIt ExitEvents = new(It.Inc<UnityUguiExitEvent>());
        public readonly ProtoIt ScrollViewEvents = new(It.Inc<UnityUguiScrollViewEvent>());
        public readonly ProtoIt SliderChangeEvents = new(It.Inc<UnityUguiSliderChangeEvent>());
        public readonly ProtoIt DropdownChangeEvents = new(It.Inc<UnityUguiDropdownChangeEvent>());
        public readonly ProtoIt InputChangeEvents = new(It.Inc<UnityUguiInputChangeEvent>());
        public readonly ProtoIt InputEndEvents = new(It.Inc<UnityUguiInputEndEvent>());
        public readonly ProtoIt UpEvents = new(It.Inc<UnityUguiUpEvent>());
    }
}