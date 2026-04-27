using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using Leopotam.EcsProto.Unity.Ugui;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared
{
    public sealed class UIEventsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<UnityUguiClickEvent> ClickEventPool;
        public readonly ProtoPool<UnityUguiDownEvent> DownEventPool;
        public readonly ProtoPool<UnityUguiDragEndEvent> DragEndEventPool;
        public readonly ProtoPool<UnityUguiDragMoveEvent> DragMoveEventPool;
        public readonly ProtoPool<UnityUguiDragStartEvent> DragStartEventPool;
        public readonly ProtoPool<UnityUguiDropEvent> DropEventPool;
        public readonly ProtoPool<UnityUguiEnterEvent> EnterEventPool;
        public readonly ProtoPool<UnityUguiExitEvent> ExitEventPool;
        public readonly ProtoPool<UnityUguiScrollViewEvent> ScrollViewEventPool;
        public readonly ProtoPool<UnityUguiSliderChangeEvent> SliderChangeEventPool;
        public readonly ProtoPool<UnityUguiDropdownChangeEvent> DropdownChangeEventPool;
        public readonly ProtoPool<UnityUguiInputChangeEvent> InputChangeEventPool;
        public readonly ProtoPool<UnityUguiInputEndEvent> InputEndEventPool;
        public readonly ProtoPool<UnityUguiUpEvent> UpEventPool;
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