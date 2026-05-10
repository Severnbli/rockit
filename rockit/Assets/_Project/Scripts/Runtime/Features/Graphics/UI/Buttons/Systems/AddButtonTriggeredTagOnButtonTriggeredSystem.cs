using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services;
using _Project.Scripts.Runtime.Features.Graphics.UI.Shared;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Systems
{
    public sealed class AddButtonTriggeredTagOnButtonTriggeredSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DI] private readonly UIEventsAspect _ueAspect;
        [DI] private ButtonsAspect _bAspect;
        private readonly Dictionary<GameObject, ProtoPackedEntityWithWorld> _goIndex;
        private ProtoWorld _world;
        
        public AddButtonTriggeredTagOnButtonTriggeredSystem(SharedIndexService siService)
        {
            _goIndex = siService.GameObjectIndex;
        }
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }
        
        public void Run()
        {
            foreach (var evE in _ueAspect.ClickEvents)
            {
                ref var data = ref _ueAspect.ClickEventPool.Get(evE);
                if (!_goIndex.TryGetEntityFromIndex(data.Sender, _world, out var tarE)) continue;
                if (!_bAspect.Buttons.Has(tarE)) continue;

                _bAspect.ButtonTriggeredTagPool.GetOrAdd(tarE);
            }
        }
    }
}