using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils.Features.Graphics
{
    public static class ButtonsUtils
    {
        public static ProtoEntity CreateCreateAllLevelButtonsRequest(RequestsAspect aspect,
            CreateAllLevelButtonsRequest prepared)
        {
            return aspect.CreateRequest(aspect.UIRequestsAspect.ButtonsRequestsAspect.CreateAllLevelButtonsRequestPool,
                prepared: prepared);
        }

        public static ProtoEntity CreateCreateLevelButtonRequest(RequestsAspect aspect,
            CreateLevelButtonRequest prepared)
        {
            return aspect.CreateRequest(aspect.UIRequestsAspect.ButtonsRequestsAspect.CreateLevelButtonRequestPool,
                prepared: prepared);
        }
    }
}