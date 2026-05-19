using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Project.Monos;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics.UI.Windows;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Project.Systems
{
    public sealed class UpdateControlsWindowInfoOnInitSystem : IProtoInitSystem
    {
        private readonly ControlsWindow _cWindow;
        private readonly LocalizationService _lService;

        public UpdateControlsWindowInfoOnInitSystem(ControlsWindow cWindow, LocalizationService lService)
        {
            _cWindow = cWindow;
            _lService = lService;
        }

        public void Init(IProtoSystems systems)
        {
            _cWindow.UpdateInfo(_lService);
        }
    }
}