using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Systems
{
    public sealed class SendCloseAppRequestOnCloseButtonTriggeredSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect; 
        [DI] private readonly ButtonsAspect _bsAspect;

        public void Run()
        {
            foreach (var e in _bsAspect.TriggeredCloseAppButtons)
            {
                SharedUtils.CreateCloseAppRequest(_rAspect);
            }
        }
    }
}