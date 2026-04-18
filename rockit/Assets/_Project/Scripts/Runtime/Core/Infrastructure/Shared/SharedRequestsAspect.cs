using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared
{
    public class SharedRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<InitializeRequest> InitializeRequestPool;
    }
}