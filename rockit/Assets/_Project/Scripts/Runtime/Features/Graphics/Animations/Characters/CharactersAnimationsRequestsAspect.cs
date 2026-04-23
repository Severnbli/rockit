using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Characters
{
    public sealed class CharactersAnimationsRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<KillCharacterRequest> KillCharacterRequestPool;
        public readonly ProtoPool<ReviveCharacterRequest> ReviveCharacterRequestPool;
        public readonly ProtoIt KillCharacterRunRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, KillCharacterRequest>());
        public readonly ProtoIt ReviveCharacterRunRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, ReviveCharacterRequest>());
    }
}