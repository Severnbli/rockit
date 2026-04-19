using _Project.Scripts.Runtime.Shared.Callback.Events;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Shared.Callback
{
    public sealed class CallbackAspect : ProtoAspectInject
    {
        public readonly ProtoPool<UnityPhysics2DCollisionStayEvent> CollisionStayEvent;
    }
}