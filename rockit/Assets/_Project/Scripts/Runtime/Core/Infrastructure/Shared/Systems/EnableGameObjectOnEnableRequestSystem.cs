using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Systems
{
    public sealed class EnableGameObjectOnEnableRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DIRequests] private readonly SharedRequestsAspect _srAspect;
        [DI] private readonly SharedAspect _sAspect;
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var reqE in _srAspect.EnableRequests)
            {
                if (!_crAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_sAspect.GameObjects.Has(tarE)) continue;

                ref var goComponent = ref _sAspect.GameObjectComponentPool.Get(tarE);
                goComponent.GameObject.SetActive(true);
            }
        }
    }
}