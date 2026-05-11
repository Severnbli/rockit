using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Systems
{
    public sealed class SendCloseAppRequestOnClickedCloseAppItemSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect; 
        [DI] private readonly UISharedAspect _uiShared;

        public void Run()
        {
            if (_uiShared.ClickedCloseAppItems.IsEmptySlow()) return;
            SharedUtils.CreateCloseAppRequest(_rAspect);
        }
    }
}