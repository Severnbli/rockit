using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons
{
    public sealed class ButtonsRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<SpawnAllLevelButtonsRequest> SpawnAllLevelButtonsRequestPool;
        public readonly ProtoPool<SpawnLevelButtonRequest> SpawnLevelButtonRequestPool;
        public readonly ProtoIt SpawnAllLevelButtonsRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, SpawnAllLevelButtonsRequest>());
        public readonly ProtoIt SpawnLevelButtonRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, SpawnLevelButtonRequest>());
    }
}