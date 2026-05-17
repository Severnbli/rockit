using System.Globalization;
using System.Text;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.Stats.Constants.Monos;
using _Project.Scripts.Runtime.Features.Stats.Constants.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Features.Stats;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Systems
{
    public sealed class RebuildConstantDisplayWindowOnRebuildConstantDisplayWindowRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly ConstantsRequestsAspect _crAspect;
        private readonly ConstantDisplayWindowService _cdwService;
        private readonly ConstantDisplayWindow _cdWindow;
        private readonly LocalizationService _lService;
        private readonly DataProvider _dProvider;

        public RebuildConstantDisplayWindowOnRebuildConstantDisplayWindowRequestSystem(ConstantDisplayWindowService cdwService, 
            ConstantDisplayWindow cdWindow, LocalizationService lService, DataProvider dProvider)
        {
            _cdwService = cdwService;
            _cdWindow = cdWindow;
            _lService = lService;
            _dProvider = dProvider;
        }

        public void Run()
        {
            var (e, ok) = _crAspect.RebuildConstantDisplayWindowRequests.FirstSlow();
            if (!ok) return;

            if (!_cdwService.Prepared) return;

            ref var rcdwRequest = ref _crAspect.RebuildConstantDisplayWindowRequestPool.Get(e);
            var investigated = ConstantsUtils.GetInvestigatedStatus(_dProvider, rcdwRequest.ConstantId);
            
            ConstructWindow(investigated);
        }

        private void ConstructWindow(bool investigated)
        {
            ConstructName(investigated);
            ConstructInfo(investigated);
            ConstructButton(investigated);
        }

        private void ConstructName(bool investigated)
        {
            var def = _cdwService.Definition;

            _cdWindow.NameText.text = string.Format(_lService.GetString(LocalizationEntriesContracts.Const.WithNameS),
                _lService.GetString(def.Name()));
        }

        private void ConstructInfo(bool investigated)
        {
            _cdWindow.InfoText.text = investigated ? GetInvestigatedInfo() : GetNotInvestigatedInfo();
        }

        private string GetInvestigatedInfo()
        {
            var sb = new StringBuilder();
            var def = _cdwService.Definition;
            var element = _cdwService.Observer.Element;
            
            sb.Append(string.Format(_lService.GetString(LocalizationEntriesContracts.Const.DiscovererInfo),
                _lService.GetString(def.Name()), _lService.GetString(def.Discoverer())));
            sb.AppendLine();
            
            sb.AppendLine(string.Format(_lService.GetString(LocalizationEntriesContracts.Const.CurrValue),
                element.Value.Value.ToString("F", CultureInfo.InvariantCulture)));
            sb.AppendLine();

            var nextElement = element.Next;
            sb.AppendLine(nextElement == null 
                ? _lService.GetString(LocalizationEntriesContracts.Const.CurrValueIsMax)
                : string.Format(_lService.GetString(LocalizationEntriesContracts.Const.ImproveInfo),
                    nextElement.Value.Value.ToString("F", CultureInfo.InvariantCulture)));
            sb.AppendLine();

            sb.AppendLine(_lService.GetString(def.Info()));
            
            return sb.ToString();
        }

        private string GetNotInvestigatedInfo()
        {
            return _lService.GetString(LocalizationEntriesContracts.Const.UndefinedInfo);
        }

        private void ConstructButton(bool investigated)
        {
            var maxImprovements = _cdwService.Observer.Element.Next == null;
            var active = investigated && !maxImprovements;
            _cdWindow.ImproveButton.gameObject.SetActive(active);
        }
    }
}