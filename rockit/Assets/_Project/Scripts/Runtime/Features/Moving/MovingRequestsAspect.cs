using _Project.Scripts.Runtime.Features.Moving.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Moving
{
    public class MovingRequestsAspect : ProtoAspectInject
    {
        public ProtoPool<WalkRequest> WalkRequestPool;
        public ProtoPool<JumpRequest> JumpRequestPool;
        public ProtoPool<DashRequest> DashRequestPool;
    }
}