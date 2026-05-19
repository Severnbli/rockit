using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.World.Levels.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.World.Levels
{
    public sealed class LevelsRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<SpawnLevelRequest> SpawnLevelRequestPool;
        public readonly ProtoIt SpawnLevelRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, SpawnLevelRequest>());
    }
}