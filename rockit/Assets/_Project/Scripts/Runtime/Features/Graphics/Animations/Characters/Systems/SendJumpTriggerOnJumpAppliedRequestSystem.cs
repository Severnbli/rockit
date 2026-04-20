using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Systems
{
    public sealed class SendJumpTriggerOnJumpAppliedRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly CharactersMovingRequestsAspect _cmrAspect;
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DI] private readonly AnimationsSharedAspect _asAspect;
        private readonly CharacterAnimationConfig _caConfig;
        private ProtoWorld _world;

        public SendJumpTriggerOnJumpAppliedRequestSystem(CharacterAnimationConfig caConfig)
        {
            _caConfig = caConfig;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var reqE in _cmrAspect.JumpAppliedRunRequests)
            {
                if (!_crAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_asAspect.CharacterAnimators.Has(tarE)) continue;

                ref var aComponent = ref _asAspect.AnimatorComponentPool.Get(tarE);
                aComponent.Animator.SetTrigger(_caConfig.JumpTrigger);
            }
        }
    }
}