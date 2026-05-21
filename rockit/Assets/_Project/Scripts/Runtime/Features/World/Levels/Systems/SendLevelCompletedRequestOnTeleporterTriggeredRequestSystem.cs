using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.World.Teleporters;
using _Project.Scripts.Runtime.Shared.Utils.Features.World;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class SendLevelCompletedRequestOnTeleporterTriggeredRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly TeleportersRequestsAspect _trAspect;
        
        public void Run()
        {
            if (_trAspect.TeleporterTriggeredRequests.IsEmptySlow()) return;

            LevelsUtils.CreateLevelCompletedRequest(_rAspect);
        }
    }
}