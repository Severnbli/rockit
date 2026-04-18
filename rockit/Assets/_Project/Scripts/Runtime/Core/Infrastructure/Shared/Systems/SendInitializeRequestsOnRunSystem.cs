using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Systems
{
    public sealed class SendInitializeRequestsOnRunSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DI] private readonly SharedAspect _sAspect;
        
        public void Init(IProtoSystems systems)
        {
            
        }
        
        public void Run()
        {
            
        }
    }
}