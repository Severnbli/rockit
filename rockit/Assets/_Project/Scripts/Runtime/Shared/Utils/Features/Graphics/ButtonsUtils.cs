using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Requests;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Types;
using _Project.Scripts.Runtime.Features.World.Levels.Types;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Features.Stats;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils.Features.Graphics
{
    public static class ButtonsUtils
    {
        public static ProtoEntity CreateCreateAllLevelButtonsRequest(RequestsAspect aspect,
            CreateLevelButtonsRequest prepared)
        {
            return aspect.CreateRequest(aspect.UIRequestsAspect.ButtonsRequestsAspect.CreateLevelButtonsRequestPool,
                prepared: prepared);
        }

        public static LevelButtonCreateSettings DefineLevelButtonCreateSettings(int id, LevelDefinition lDefinition, 
            DataProvider dProvider)
        {
            var createSettings = new LevelButtonCreateSettings
            {
                LevelId = id,
                StarsToUnlock = lDefinition.StarsToUnlock
            };
                
            var totalStars = GameStatsUtils.GetTotalStars(dProvider);
            createSettings.Opened = totalStars >= lDefinition.StarsToUnlock;
                
            if (dProvider.GameSceneData.CompletedLevels.TryGetValue(id, out var lData))
            {
                createSettings.StarsQuantity = lData.Stars;
            }
            
            return createSettings;
        }
    }
}