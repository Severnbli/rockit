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

        [Inject]
        public void Construct(ProtoWorld world, EcsSystems systems)
        {
            _world = world;
            _systems = systems;
        }

        protected virtual void Start()
        {
            Init();
        }
        
        public void Init()
        {
            _systems?.Init();
        }

        protected virtual void Update()
        {
            Run();
        }

        public void Run()
        {
            _systems?.Run();
        }

        protected virtual void FixedUpdate()
        {
            FixedRun();
        }

        public void FixedRun()
        {
            _systems?.FixedRun();
        }

        protected virtual void OnDestroy()
        {
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