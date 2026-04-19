using _Project.Scripts.Runtime.Shared.Callback.Events;
using Leopotam.EcsProto.Unity;
using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Callback.Actions
{
    public sealed class UnityPhysics2DCollisionStayAction : ProtoUnityAction<UnityPhysics2DCollisionStayEvent>
    {
        public void OnCollisionStay2D(Collision2D collision)
        {
            if (IsValidForEvent ()) {
                ref var msg = ref NewEvent ();
                msg.SenderName = SenderName ();
                msg.Sender = Sender ();
                msg.Collider = collision.collider;
                msg.Velocity = collision.relativeVelocity;
                var cp = collision.GetContact (0);
                msg.Point = cp.point;
                msg.Normal = cp.normal;
            }
        }
    }
}