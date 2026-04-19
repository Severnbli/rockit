using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Characters
{
    public class CharactersAnimationsRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<KillCharacterRequest> KillCharacterRequestPool;
        public readonly ProtoPool<ReviveCharacterRequest> ReviveCharacterRequestPool;
        public readonly ProtoIt KillCharacterRequests = new (It.Inc<RequestComponent, ActiveRequestTag, KillCharacterRequest>());
        public readonly ProtoIt ReviveCharacterRequests = new (It.Inc<RequestComponent, ActiveRequestTag, ReviveCharacterRequest>());
    }
}