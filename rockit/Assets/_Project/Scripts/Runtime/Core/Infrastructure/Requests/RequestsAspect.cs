using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.Input;
using _Project.Scripts.Runtime.Features.Physics.Moving;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests
{
    public class RequestsAspect : ProtoAspectInject
    {
        public readonly CoreRequestsAspect CoreRequestsAspect;
        public readonly InputRequestsAspect InputRequestsAspect;
        public readonly MovingRequestsAspect MovingRequestsAspect;
        public readonly SharedAspect SharedAspect;
    }
}