using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils.Infrastructure
{
    public static class AudioUtils
    {
        public static ProtoEntity CreatePlaySfxRequest(RequestsAspect aspect, PlaySfxRequest prepared)
        {
            return aspect.CreateRequest(aspect.AudioRequestsAspect.PlaySfxRequestPool, prepared: prepared);
        }
    }
}