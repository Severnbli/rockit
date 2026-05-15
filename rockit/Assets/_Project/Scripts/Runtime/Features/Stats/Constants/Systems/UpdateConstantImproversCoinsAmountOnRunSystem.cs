using _Project.Scripts.Runtime.Features.Economy.Coins;
using _Project.Scripts.Runtime.Features.Stats.Constants.Services;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Systems
{
    public sealed class UpdateConstantImproversCoinsAmountOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly ConstantsAspect _conAspect;
        [DI] private readonly CoinsAspect _coiAspect;
        private readonly ConstantDisplayWindowService _cdwService;

        public UpdateConstantImproversCoinsAmountOnRunSystem(ConstantDisplayWindowService cdwService)
        {
            _cdwService = cdwService;
        }

        public void Run()
        {
            if (!_cdwService.Prepared) return;
            var nextElement = _cdwService.Observer.Element.Next;
            if (nextElement == null) return;
            
            foreach (var e in _conAspect.CoinsAmountConstantsImprovers)
            {
                ref var caComponent = ref _coiAspect.CoinsAmountComponentPool.Get(e);
                caComponent.Amount = nextElement.Value.CoinsAmount;
            }
        }
    }
}