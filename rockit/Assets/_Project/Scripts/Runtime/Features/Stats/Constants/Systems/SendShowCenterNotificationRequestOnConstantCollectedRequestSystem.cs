using _Project.Scripts.Runtime.Core.Infrastructure.Localization;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Requests;
using _Project.Scripts.Runtime.Features.Stats.Constants.Configs;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Features.Graphics;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Systems
{
    public sealed class SendShowCenterNotificationRequestOnConstantCollectedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly ConstantsRequestsAspect _crAspect;
        private readonly ConstantsConfig _cConfig;
        private readonly LocalizationService _lService;

        public SendShowCenterNotificationRequestOnConstantCollectedRequestSystem(ConstantsConfig cConfig, 
            LocalizationService lService)
        {
            _cConfig = cConfig;
            _lService = lService;
        }

        public void Run()
        {
            foreach (var e in _crAspect.ConstantCollectedRequests)
            {
                ref var ccRequest = ref _crAspect.ConstantCollectedRequestPool.Get(e);
                if (!_cConfig.Constants.TryGetValue(ccRequest.ConstantId, out var cDefinition)) continue;

                var prepared = new ShowCenterNotificationRequest
                {
                    Text = string.Format(_lService.GetString(LocalizationEntriesContracts.Const.InvestigatedInfo),
                        _lService.GetString(cDefinition.Name()))
                };
                NotificationsUtils.CreateShowCenterNotificationRequest(_rAspect, prepared);
            }
        }
    }
}