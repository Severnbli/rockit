using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons
{
    public sealed class ButtonsRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<SpawnLevelButtonsRequest> SpawnLevelButtonsRequestPool;
        public readonly ProtoIt SpawnLevelButtonsRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, SpawnLevelButtonsRequest>());
    }
}