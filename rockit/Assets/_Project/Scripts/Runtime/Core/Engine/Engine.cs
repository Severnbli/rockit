using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Engine
{
    public class Engine : IEngine
    {
        protected ProtoWorld _world;
        protected EcsSystems _systems;

        public Engine(ProtoWorld world, EcsSystems systems)
        {
            _world = world;
            _systems = systems;
        }
        
        public virtual void Init()
        {
            _systems?.Init();
        }

        public virtual void Run()
        {
            _systems?.Run();
        }

        public virtual void FixedRun()
        {
            _systems?.FixedRun();
        }

        public virtual void Destroy()
        {
            _systems?.Destroy();
            _systems = null;
            
            _world?.Destroy();
            _world = null;
        }
    }
}