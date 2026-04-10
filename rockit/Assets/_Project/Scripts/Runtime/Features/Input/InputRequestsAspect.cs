using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Input.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Input
{
    public class InputRequestsAspect : ProtoAspectInject
    {
        public ProtoPool<EnablePlayerInputRequest> EnablePlayerInputRequestPool;
        public ProtoPool<DisablePlayerInputRequest> DisablePlayerInputRequestPool;
        public ProtoPool<EnablePlatformsInputRequest> EnablePlatformsInputRequestPool;
        public ProtoPool<DisablePlatformsInputRequest> DisablePlatformsInputRequestPool;
        public ProtoIt EnablePlayerInputRequests = new (It.Inc<RequestComponent, ActiveRequestTag, EnablePlayerInputRequest>());
        public ProtoIt DisablePlayerInputRequests = new (It.Inc<RequestComponent, ActiveRequestTag, DisablePlayerInputRequest>());
        public ProtoIt EnablePlatformsInputRequests = new (It.Inc<RequestComponent, ActiveRequestTag, EnablePlatformsInputRequest>());
        public ProtoIt DisablePlatformsInputRequests = new (It.Inc<RequestComponent, ActiveRequestTag, DisablePlatformsInputRequest>());
    }
}