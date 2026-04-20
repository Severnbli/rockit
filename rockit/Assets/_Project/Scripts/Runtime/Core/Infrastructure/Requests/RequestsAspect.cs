using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Characters;
using _Project.Scripts.Runtime.Features.Input;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests
{
    public class RequestsAspect : ProtoAspectInject
    {
        public readonly CoreRequestsAspect CoreRequestsAspect;
        public readonly InputRequestsAspect InputRequestsAspect;
        public readonly CharactersMovingRequestsAspect CharactersMovingRequestsAspect;
        public readonly CharactersAnimationsRequestsAspect CharactersAnimationsRequestsAspect;
        public readonly SharedRequestsAspect SharedRequestsAspect;
    }
}