using System.Linq;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Systems
{
    public sealed class LoadPlatformStartStatesOnInitializeRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly SharedRequestsAspect _srAspect;
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DI] private readonly PlatformsSharedAspect _psAspect;
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var reqE in _srAspect.InitializeRunRequests)
            {
                if (!_crAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_psAspect.PlatformsWithPlatformStates.Has(tarE)) continue;

                ref var pComponent = ref _psAspect.PlatformComponentPool.Get(tarE);
                ref var psComponent = ref _psAspect.PlatformStatesComponentPool.Get(tarE);
                var pStates = pComponent.Platform.PositionStates.Select(x => x.position).ToList();
                var rStates = pComponent.Platform.RotationStates.Select(x => x.rotation).ToList();
                var sStates = pComponent.Platform.ScaleStates.Select(x => x.localScale).ToList();

                SequenceElementUtils.TryCreateLoopedSequence(pStates, out psComponent.StartPosState);
                SequenceElementUtils.TryCreateLoopedSequence(rStates, out psComponent.StartRotState);
                SequenceElementUtils.TryCreateLoopedSequence(sStates, out psComponent.StartScaleState);
            }
        }
    }
}