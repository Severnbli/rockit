using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Configs;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class RestartLevelOnVoidTouchedSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly PhysicsEventsAspect _peAspect;
        private readonly LayersConfig _lConfig;

        public RestartLevelOnVoidTouchedSystem(LayersConfig lConfig)
        {
            _lConfig = lConfig;
        }

        public void Run()
        {
            LogUtils.Log("A");
            foreach (var e in _peAspect.TriggerEnterEvents)
            {
                LogUtils.Log("TRIGGER");
                
                var prepared = new SwitchSceneRequest
                {
                    Target = ScenesContracts.GameScene
                };

                ScenesUtils.CreateSwitchSceneRequest(_rAspect, prepared);
                
                ref var data = ref _peAspect.TriggerEnterEventPool.Get(e);
                if (data.Collider.gameObject.layer != _lConfig.VoidLayer) continue;
            }
        }
    }
}