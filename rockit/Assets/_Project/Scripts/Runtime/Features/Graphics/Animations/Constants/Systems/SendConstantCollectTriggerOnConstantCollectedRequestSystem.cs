using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Constants.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared;
using _Project.Scripts.Runtime.Features.Stats.Constants;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Constants.Systems
{
    public sealed class SendConstantCollectTriggerOnConstantCollectedRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly ConstantsRequestsAspect _crAspect;
        [DI] private readonly ConstantsAnimationsAspect _caAspect;
        [DI] private readonly AnimationsSharedAspect _asAspect;
        private readonly ConstantsAnimationsConfig _caConfig;
        private ProtoWorld _world;

        public SendConstantCollectTriggerOnConstantCollectedRequestSystem(ConstantsAnimationsConfig caConfig)
        {
            _caConfig = caConfig;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var reqE in _crAspect.ConstantCollectedRequests)
            {
                if (!_rAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_caAspect.ConstantAnimators.Has(tarE)) continue;

                ref var aComponent = ref _asAspect.AnimatorComponentPool.Get(tarE);
                aComponent.Animator.SetTrigger(_caConfig.CollectTrigger);
            }
        }
    }
}