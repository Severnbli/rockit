using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Tools;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Systems
{
    public sealed class LoadPlatformPositionStatesOnInitializeRequestSystem : IProtoInitSystem, IProtoRunSystem
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
                var pStates = pComponent.Platform.PositionStates;

                if (!pStates.Any()) return;
                
                CreateSequence(pStates, out var first);
                pComponent.CurPosState = first;
            }
        }

        private void CreateSequence(List<Transform> pStates, out SequenceElement<Vector3> first)
        {
            first = new SequenceElement<Vector3>(pStates[0].position);
            var prev = first;

            for (var i = 1; i < pStates.Count; i++)
            {
                var curr = new SequenceElement<Vector3>(pStates[i].position);
                prev.Next = curr;
                curr.Prev = prev;
                prev = curr;
            }

            if (prev == first) return;
            
            prev.Next = first;
            first.Prev = prev;
        }
    }
}