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
    public sealed class LoadPlatformRotationStatesOnInitializeRequestSystem : IProtoInitSystem, IProtoRunSystem
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
                var rStates = pComponent.Platform.RotationStates;

                if (!rStates.Any()) return;
                
                CreateSequence(rStates, out var first);
                pComponent.StartRotState = first;
            }
        }

        private void CreateSequence(List<Transform> pStates, out SequenceElement<Quaternion> first)
        {
            first = new SequenceElement<Quaternion>(pStates[0].rotation);
            var prev = first;

            for (var i = 1; i < pStates.Count; i++)
            {
                var curr = new SequenceElement<Quaternion>(pStates[i].rotation);
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