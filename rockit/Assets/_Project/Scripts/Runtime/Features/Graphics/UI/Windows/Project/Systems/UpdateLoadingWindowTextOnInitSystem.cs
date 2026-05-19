using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Project.Monos;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics.UI.Windows;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Project.Systems
{
    public sealed class UpdateLoadingWindowTextOnInitSystem : IProtoInitSystem
    {
        private readonly LoadingWindow _lWindow;
        private readonly LocalizationService _lService;
        
        public UpdateLoadingWindowTextOnInitSystem(LoadingWindow lWindow, LocalizationService lService)
        {
            _lWindow = lWindow;
            _lService = lService;
        }

        public void Init(IProtoSystems systems)
        {
            _lWindow.UpdateText(_lService);
        }
    }
}