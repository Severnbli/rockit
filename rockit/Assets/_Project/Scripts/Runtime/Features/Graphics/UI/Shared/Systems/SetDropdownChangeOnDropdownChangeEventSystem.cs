using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Systems
{
    public sealed class SetDropdownChangeOnDropdownChangeEventSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DI] private readonly UIEventsAspect _ueAspect;
        [DI] private readonly UISharedAspect _usAspect;
        private readonly Dictionary<GameObject, ProtoPackedEntityWithWorld> _goIndex;
        private ProtoWorld _world;

        public SetDropdownChangeOnDropdownChangeEventSystem(SharedIndexService siService)
        {
            _goIndex = siService.GameObjectIndex;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var evE in _ueAspect.DropdownChangeEvents)
            {
                ref var data = ref _ueAspect.DropdownChangeEventPool.Get(evE);
                if (!_goIndex.TryGetEntityFromIndex(data.Sender.gameObject, _world, out var tarE)) continue;

                ref var dcComponent = ref _usAspect.DropdownChangeComponentPool.Get(tarE);
                dcComponent.Value = data.Value;
            }
        }
    }
}