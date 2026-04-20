using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Configs;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class JumpBufferingExpireSystem : IProtoRunSystem
    {
        [DI] private CharactersMovingAspect _cmAspect; 
        private readonly TimeService _tService;
        private readonly SharedCharacterMovingConfig _smConfig;

        public JumpBufferingExpireSystem(TimeService tService, SharedCharacterMovingConfig smConfig)
        {
            _tService = tService;
            _smConfig = smConfig;
        }

        public void Run()
        {
            foreach (var e in _cmAspect.JumpBuffers)
            {
                ref var jbComponent = ref _cmAspect.JumpBufferingComponentPool.Get(e);
                
                if (!MovingUtils.JumpBufferingTimeExpired(jbComponent, _tService, _smConfig)) continue;
                
                _cmAspect.JumpBufferingComponentPool.Del(e);
            }
        }
    }
}