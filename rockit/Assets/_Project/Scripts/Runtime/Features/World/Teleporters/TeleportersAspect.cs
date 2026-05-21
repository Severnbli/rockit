using _Project.Scripts.Runtime.Features.World.Teleporters.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.World.Teleporters
{
    public sealed class TeleportersAspect : ProtoAspectInject
    {
        public readonly ProtoPool<TeleporterTag> TeleporterTagPool;
        public readonly ProtoIt Teleportes = new (It.Inc<TeleporterTag>());
    }
}