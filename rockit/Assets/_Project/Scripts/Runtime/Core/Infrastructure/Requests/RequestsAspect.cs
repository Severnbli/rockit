using _Project.Scripts.Runtime.Features.Input;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests
{
    public class RequestsAspect : ProtoAspectInject
    {
        public CoreRequestsAspect CoreRequestsAspect;
        public InputRequestsAspect InputRequestsAspect;
    }
}