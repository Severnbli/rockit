using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Shared.Extensions.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Systems
{
    public sealed class ManageInvestigatedConstantTagExistenceByStorageOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly ConstantsAspect _cAspect;
        private readonly DataProvider _dProvider;

        public ManageInvestigatedConstantTagExistenceByStorageOnRunSystem(DataProvider dProvider)
        {
            _dProvider = dProvider;
        }

        public void Run()
        {
            var sData = _dProvider.StatsData;
            
            foreach (var e in _cAspect.Constants)
            {
                ref var cComponent = ref _cAspect.ConstantComponentPool.Get(e);
                var existence = sData.InvestigatedConstants.ContainsKey(cComponent.Id);
                _cAspect.InvestigatedConstantTagPool.AddOrDelOnCondition(e, existence);
            }
        }
    }
}