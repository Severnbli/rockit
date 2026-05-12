using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Requests;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Systems
{
    public sealed class SendSwitchSceneRequestOnClickedGameSceneOpenerSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly UISharedAspect _usAspect;
        
        public void Run()
        {
            if (_usAspect.ClickedLevelItemOpeners.IsEmptySlow()) return;

            var prepared = new SwitchSceneRequest
            {
                Target = ScenesContracts.GameScene
            };

            ScenesUtils.CreateSwitchSceneRequest(_rAspect, prepared: prepared);
        }
    }
}