using _Project.Scripts.Runtime.Features.Input.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Moving.Systems
{
    public class TranslatePlayerInputWalkIntoMovingWalkRequestSystem : IProtoRunSystem
    {
        private readonly PlayerInputService _service;

        public TranslatePlayerInputWalkIntoMovingWalkRequestSystem(PlayerInputService service)
        {
            _service = service;
        }

        public void Run()
        {
            
        }
    }
}