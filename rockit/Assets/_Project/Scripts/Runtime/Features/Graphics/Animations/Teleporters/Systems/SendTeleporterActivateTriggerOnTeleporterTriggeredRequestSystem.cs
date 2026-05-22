using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Teleporters.Configs;
using _Project.Scripts.Runtime.Features.World.Teleporters;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Teleporters.Systems
{
    public sealed class SendTeleporterActivateTriggerOnTeleporterTriggeredRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly TeleportersRequestsAspect _trAspect;
        [DI] private readonly TeleportersAnimationsAspect _taAspect;
        [DI] private readonly AnimationsSharedAspect _asAspect;
        private readonly TeleportersAnimationsConfig _taConfig;
        private ProtoWorld _world;

        public SendTeleporterActivateTriggerOnTeleporterTriggeredRequestSystem(TeleportersAnimationsConfig taConfig)
        {
            _taConfig = taConfig;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var reqE in _trAspect.TeleporterTriggeredRequests)
            {
                if (!_rAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_taAspect.TeleporterAnimators.Has(tarE)) continue;

                ref var aComponent = ref _asAspect.AnimatorComponentPool.Get(tarE);
                aComponent.Animator.SetTrigger(_taConfig.ActivateTrigger);
            }
        }
    }
}