using Leopotam.EcsProto.QoL;
using Leopotam.EcsProto.Unity.Physics2D;
using Leopotam.EcsProto.Unity.Ugui;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public class DomainAspect : ProtoAspectInject
    {
        public UnityUguiAspect UguiAspect;
        public UnityPhysics2DAspect Physics2DAspect;
    }
}