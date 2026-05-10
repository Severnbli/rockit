using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services;
using _Project.Scripts.Runtime.Features.Graphics.UI.Shared;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Systems
{
    public sealed class SendCloseAppRequestOnCloseButtonClickedSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly UIEventsAspect _ueAspect;
        [DI] private ButtonsAspect _bsAspect;
        private readonly Dictionary<GameObject, ProtoPackedEntityWithWorld> _goIndex;
        private ProtoWorld _world;

        public SendCloseAppRequestOnCloseButtonClickedSystem(SharedIndexService siService)
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
                if (!_bsAspect.CloseAppButtons.Has(tarE)) continue;

                SharedUtils.CreateCloseAppRequest(_rAspect);
            }
        }
    }
}