using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Engine
{
    public class MonoEngine : MonoBehaviour, IEngine
    {
        protected ProtoWorld _world;
        protected EcsSystems _systems;
        protected bool Inited = false;

        [Inject]
        public void Construct(ProtoWorld world, EcsSystems systems)
        {
            _world = world;
            _systems = systems;
        }
        
        public void Init()
        {
            if (Inited) return;
            _systems?.Init();
            Inited = true;
        }

        protected virtual void Update()
        {
            Run();
        }

        public void Run()
        {
            if (!Inited) return;
            _systems?.Run();
        }

        protected virtual void FixedUpdate()
        {
            FixedRun();
        }

        public void FixedRun()
        {
            if (!Inited) return;
            _systems?.FixedRun();
        }

        protected virtual void OnDestroy()
        {
            if (!Inited) return;
            Destroy();
        }

        public void Destroy()
        {
            _systems?.Destroy();
            _systems = null;
            
            _world?.Destroy();
            _world = null;
        }
    }
}