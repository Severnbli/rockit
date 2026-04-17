using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class ApplyDashTimeoutOnDashTimeoutRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            
        }
    }
}