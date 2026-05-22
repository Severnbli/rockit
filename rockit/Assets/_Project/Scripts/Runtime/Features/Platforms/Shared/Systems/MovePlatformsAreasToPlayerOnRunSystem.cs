using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Configs;
using _Project.Scripts.Runtime.Features.Player;
using _Project.Scripts.Runtime.Shared.Extensions.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Systems
{
    public sealed class MovePlatformsAreasToPlayerOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly PlatformsSharedAspect _psAspect;
        [DI] private readonly PlayerAspect _pAspect;
        [DI] private readonly SharedAspect _sAspect;
        private readonly PlatformsAreaConfig _paConfig;

        public MovePlatformsAreasToPlayerOnRunSystem(PlatformsAreaConfig paConfig)
        {
            _paConfig = paConfig;
        }

        public void Run()
        {
            if (_psAspect.TransformPlatformsAreas.IsEmptySlow()) return;
            
            var (pe, ok) = _pAspect.TransformPlayers.FirstSlow();
            if (!ok) return;

            ref var ptComponent = ref _sAspect.TransformComponentPool.Get(pe);
            var target = (Vector2)ptComponent.Transform.position + _paConfig.PlayerOffset;

            foreach (var e in _psAspect.TransformPlatformsAreas)
            {
                ref var tComponent = ref _sAspect.TransformComponentPool.Get(e);
                tComponent.Transform.PlaceTo(target);
            }
        }
    }
}