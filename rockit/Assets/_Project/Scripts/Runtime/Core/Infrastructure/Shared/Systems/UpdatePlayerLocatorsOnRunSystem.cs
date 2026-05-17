using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Systems
{
    public sealed class UpdatePlayerLocatorsOnRunSystem : IProtoRunSystem
    {
        [DI] private SharedAspect _sAspect;
        
        public void Run()
        {
            var (pe, ok) = _sAspect.TransformPlayers.FirstSlow();
            if (!ok) return;

            ref var ptComponent = ref _sAspect.TransformComponentPool.Get(pe);

            foreach (var e in _sAspect.TransformPlayerLocators)
            {
                ref var plComponent = ref _sAspect.PlayerLocatorComponentPool.GetOrAdd(e);
                ref var tComponent = ref _sAspect.TransformComponentPool.Get(e);
                plComponent.Distance = Vector2.Distance(ptComponent.Transform.position, tComponent.Transform.position);
            }
        }
    }
}