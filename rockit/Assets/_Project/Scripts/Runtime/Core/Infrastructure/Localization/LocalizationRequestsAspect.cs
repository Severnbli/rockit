using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization
{
    public sealed class LocalizationRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<ChangeLanguageRequest> ChangeLanguageRequestPool;
        public readonly ProtoPool<UpdateLocalizationItemRequest> UpdateLocalizationItemRequestPool;
        public readonly ProtoIt ChangeLanguageRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, ChangeLanguageRequest>());
        public readonly ProtoIt UpdateLocalizationItemRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, UpdateLocalizationItemRequest>());
    }
}