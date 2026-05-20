using System.Threading;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Requests;
using _Project.Scripts.Runtime.Shared.Utils.Features.Graphics;
using Cysharp.Threading.Tasks;
using Unity.Cinemachine;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Tools.Switcher
{
    public class CameraSwitcher : ICameraSwitcher
    {
        protected readonly CancellationToken Ct;
        protected readonly ICameraSwitchAwaiter CsAwaiter;
        protected readonly RequestsAspect RAspect;

        public CameraSwitcher(CancellationToken ct, ICameraSwitchAwaiter csAwaiter, RequestsAspect rAspect)
        {
            Ct = ct;
            CsAwaiter = csAwaiter;
            RAspect = rAspect;
        }

        public async UniTask SwitchTo(CinemachineCamera camera)
        {
            var prepared = new SwitchCameraRequest
            {
                Target = camera
            };
            CamerasUtils.CreateSwitchCameraRequest(RAspect, prepared);

            await CsAwaiter.AwaitSwitch(Ct);
        }
    }
}