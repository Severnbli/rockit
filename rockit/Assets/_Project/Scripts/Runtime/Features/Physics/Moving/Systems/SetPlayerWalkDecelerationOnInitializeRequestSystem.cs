using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class SetPlayerWalkDecelerationOnInitializeRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly SharedRequestsAspect _srAspect;
        
        public void Run()
        {
            
        }
    }
}