using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Systems
{
    public sealed class SendDashTriggerOnDashRequestSystem : IProtoInitSystem, IProtoFixedRunSystem
    {
        [DIRequests] private readonly CharactersMovingRequestsAspect _cmrAspect;
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DI] private readonly AnimationsSharedAspect _asAspect;
        [DI] private readonly CharactersMovingAspect _cmAspect;
        private readonly CharacterAnimationConfig _caConfig;
        private ProtoWorld _world;

        public SendDashTriggerOnDashRequestSystem(CharacterAnimationConfig caConfig)
        {
            _caConfig = caConfig;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void FixedRun()
        {
            foreach (var reqE in _cmrAspect.DashRequests)
            {
                if (!_crAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_cmAspect.Dashables.Has(tarE) || !_asAspect.CharacterAnimators.Has(tarE)) continue;
                
                ref var aComponent = ref _asAspect.AnimatorComponentPool.Get(tarE);
                aComponent.Animator.SetTrigger(_caConfig.DashTrigger);
            }
        }
    }
}