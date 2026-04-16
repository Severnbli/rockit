using _Project.Scripts.Runtime.Features.Input;
using _Project.Scripts.Runtime.Features.Physics.Moving;
using _Project.Scripts.Runtime.Shared;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests
{
    public class RequestsAspect : ProtoAspectInject
    {
        public CoreRequestsAspect CoreRequestsAspect;
        public InputRequestsAspect InputRequestsAspect;
        public MovingRequestsAspect MovingRequestsAspect;
        public SharedAspect SharedAspect;
    }
}