using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Input.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Moving.Systems
{
    public class TranslatePlayerInputWalkToWalkRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _aspect;
        private readonly PlayerInputService _service;

        public TranslatePlayerInputWalkToWalkRequestSystem(PlayerInputService service)
        {
            _service = service;
        }

        public void Run()
        {
            
        }
    }
}