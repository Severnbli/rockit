using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes
{
    public sealed class ScenesRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<SwitchSceneRequest> SwitchSceneRequestPool;
        public readonly ProtoIt SwitchSceneRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, SwitchSceneRequest>());
    }
}