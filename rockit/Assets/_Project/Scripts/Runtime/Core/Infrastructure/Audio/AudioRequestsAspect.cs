using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio
{
    public sealed class AudioRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<PlaySfxRequest> PlaySfxRequestPool;
        public readonly ProtoIt PlaySfxRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, PlaySfxRequest>());
    }
}