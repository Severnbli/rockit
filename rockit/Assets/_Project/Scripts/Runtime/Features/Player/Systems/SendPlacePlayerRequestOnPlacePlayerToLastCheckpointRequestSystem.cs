using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Player.Requests;
using _Project.Scripts.Runtime.Features.World.Checkpoints.Services;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using _Project.Scripts.Runtime.Shared.Utils.Features;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Player.Systems
{
    public sealed class SendPlacePlayerRequestOnPlacePlayerToLastCheckpointRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly PlayerRequestsAspect _prAspect;
        private readonly CheckpointsService _cService;
        private readonly LevelsService _lService;

        public SendPlacePlayerRequestOnPlacePlayerToLastCheckpointRequestSystem(CheckpointsService cService, 
            LevelsService lService)
        {
            _cService = cService;
            _lService = lService;
        }

        public void Run()
        {
            if (_prAspect.PlacePlayerToLastCheckpointRequests.IsEmptySlow()) return;

            var target = _cService.LastCheckpoint != null
                ? _cService.LastCheckpoint.GetCheckLocation()
                : (Vector2) _lService.CurrLevel.PsPosition.transform.position;

            var prepared = new PlacePlayerRequest
            {
                To = target
            };
            PlayerUtils.CreatePlacePlayerRequest(_rAspect, prepared);
        }
    }
}