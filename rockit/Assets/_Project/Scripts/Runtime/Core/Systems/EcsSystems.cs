using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Systems
{
    public class EcsSystems : ProtoSystems
    {
        protected Slice<IProtoFixedRunSystem> _fixedRunsystems;
        
        public EcsSystems(ProtoWorld defaultWorld) : base(defaultWorld)
        {
        }
    }
}