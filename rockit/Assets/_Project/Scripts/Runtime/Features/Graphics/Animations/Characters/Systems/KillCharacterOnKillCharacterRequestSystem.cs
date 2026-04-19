using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Systems
{
    public sealed class KillCharacterOnKillCharacterRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly CharactersAnimationsRequestsAspect _carAspect;
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DI] private readonly AnimationsSharedAspect _asAspect;
        private readonly CharacterAnimationConfig _caConfig;
        private ProtoWorld _world;

        public KillCharacterOnKillCharacterRequestSystem(CharacterAnimationConfig caConfig)
        {
            _caConfig = caConfig;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var reqE in _carAspect.KillCharacterRunRequests)
            {
                if (!_crAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_asAspect.CharacterAnimators.Has(tarE)) continue;
                
                ref var aComponent = ref _asAspect.AnimatorComponentPool.Get(tarE);
                aComponent.Animator.SetTrigger(_caConfig.DeathTrigger);
                aComponent.Animator.SetBool(_caConfig.DeadBool, true);
            }
        }
    }
}