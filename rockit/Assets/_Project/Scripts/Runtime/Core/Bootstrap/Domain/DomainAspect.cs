using _Project.Scripts.Runtime.Features.Input;
using _Project.Scripts.Runtime.Features.Physics.Moving;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared;
using Leopotam.EcsProto.QoL;
using Leopotam.EcsProto.Unity.Physics2D;
using Leopotam.EcsProto.Unity.Ugui;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public class DomainAspect : ProtoAspectInject
    {
        public UnityUguiAspect UguiAspect;
        public UnityPhysics2DAspect Physics2DAspect;
        public InputAspect InputAspect;
        public PhysicsSharedAspect PhysicsSharedAspect;
        public MovingAspect MovingAspect;
        public SharedAspect SharedAspect;
    }
}