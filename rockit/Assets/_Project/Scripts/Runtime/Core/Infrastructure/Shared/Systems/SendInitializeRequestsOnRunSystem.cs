using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Systems
{
    public sealed class SendInitializeRequestsOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly SharedAspect _sAspect;
        
        public void Run()
        {
            
        }
    }
}