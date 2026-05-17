using _Project.Scripts.Runtime.Features.Stats.Constants;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Stats.Shared
{
    public sealed class StatsSharedRequestsAspect : ProtoAspectInject
    {
        public readonly ConstantsRequestsAspect ConstantsRequestsAspect;
    }
}