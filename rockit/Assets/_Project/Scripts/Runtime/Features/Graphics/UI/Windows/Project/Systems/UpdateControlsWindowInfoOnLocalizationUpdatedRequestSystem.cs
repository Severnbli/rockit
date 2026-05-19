using _Project.Scripts.Runtime.Core.Infrastructure.Localization;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Project.Monos;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics.UI.Windows;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Project.Systems
{
    public sealed class UpdateControlsWindowInfoOnLocalizationUpdatedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LocalizationRequestsAspect _lrAspect;
        private readonly ControlsWindow _cWindow;
        private readonly LocalizationService _lService;

        public UpdateControlsWindowInfoOnLocalizationUpdatedRequestSystem(ControlsWindow cWindow, LocalizationService lService)
        {
            _cWindow = cWindow;
            _lService = lService;
        }

        public void Run()
        {
            if (_lrAspect.LocalizationUpdatedRequests.IsEmptySlow()) return;
            
            _cWindow.UpdateInfo(_lService);
        }
    }
}