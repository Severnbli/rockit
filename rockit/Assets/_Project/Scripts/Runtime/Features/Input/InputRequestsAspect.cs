using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Input.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Input
{
    public sealed class InputRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<EnablePlayerInputRequest> EnablePlayerInputRequestPool;
        public readonly ProtoPool<DisablePlayerInputRequest> DisablePlayerInputRequestPool;
        public readonly ProtoPool<EnablePlatformsInputRequest> EnablePlatformsInputRequestPool;
        public readonly ProtoPool<DisablePlatformsInputRequest> DisablePlatformsInputRequestPool;
        public readonly ProtoPool<PlayerInputEnabledRequest> PlayerInputEnabledRequestPool;
        public readonly ProtoPool<PlayerInputDisabledRequest> PlayerInputDisabledRequestPool;
        public readonly ProtoPool<PlatformsInputEnabledRequest> PlatformsInputEnabledRequestPool;
        public readonly ProtoIt EnablePlayerInputRequests = new (It.Inc<RequestComponent, ActiveRequestTag, EnablePlayerInputRequest>());
        public readonly ProtoIt DisablePlayerInputRequests = new (It.Inc<RequestComponent, ActiveRequestTag, DisablePlayerInputRequest>());
        public readonly ProtoIt EnablePlatformsInputRequests = new (It.Inc<RequestComponent, ActiveRequestTag, EnablePlatformsInputRequest>());
        public readonly ProtoIt DisablePlatformsInputRequests = new (It.Inc<RequestComponent, ActiveRequestTag, DisablePlatformsInputRequest>());
        public readonly ProtoIt PlayerInputEnabledRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, PlayerInputEnabledRequest>());
        public readonly ProtoIt PlayerInputDisabledRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, DisablePlayerInputRequest>());
        public readonly ProtoIt PlatformsInputEnabledRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, PlatformsInputEnabledRequest>());
    }
}