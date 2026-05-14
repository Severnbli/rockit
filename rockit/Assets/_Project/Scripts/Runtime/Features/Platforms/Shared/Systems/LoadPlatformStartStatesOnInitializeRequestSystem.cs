using System.Linq;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Shared;
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
                if (!_psAspect.Platforms.Has(tarE)) continue;

                ref var pComponent = ref _psAspect.PlatformComponentPool.Get(tarE);
                ref var psComponent = ref _psAspect.PlatformStatesComponentPool.GetOrAdd(tarE);
                var pStates = pComponent.Platform.PositionStates.Select(x => x.position).ToList();
                var rStates = pComponent.Platform.RotationStates.Select(x => x.rotation).ToList();
                var sStates = pComponent.Platform.ScaleStates.Select(x => x.localScale).ToList();

                SequenceElementUtils.TryCreateSequence(pStates, out psComponent.StartPosState, true);
                SequenceElementUtils.TryCreateSequence(rStates, out psComponent.StartRotState, true);
                SequenceElementUtils.TryCreateSequence(sStates, out psComponent.StartScaleState, true);
            }
        }
    }
}