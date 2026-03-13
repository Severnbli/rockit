using System.Collections.Generic;
using Leopotam.EcsProto;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Engine
{
    public class MonoEngine : MonoBehaviour, IEngine
    {
        [Inject] private ProtoWorld _world;
        private ProtoSystems _runSystems;
        private ProtoSystems _fixedRunSystems;
        
        [Inject(Id = Contracts.RunSystems)]
        public void ConstructRunSystems(List<IProtoSystem> systems)
        {
            _runSystems = new ProtoSystems(_world);
            foreach (var system in systems)
            {
                _runSystems.AddSystem(system);
            }
        }
        
        [Inject(Id = Contracts.FixedRunSystems)]
        public void Construct(List<IProtoSystem> systems)
        {
            _fixedRunSystems = new ProtoSystems(_world);
            foreach (var system in systems)
            {
                _fixedRunSystems.AddSystem(system);
            }
        }

        protected virtual void Start()
        {
            Init();
        }
        
        public void Init()
        {
            _runSystems?.Init();
        }

        protected virtual void Update()
        {
            Run();
        }

        public void Run()
        {
            _runSystems?.Run();
        }

        protected virtual void FixedUpdate()
        {
            FixedRun();
        }

        public void FixedRun()
        {
            _fixedRunSystems?.Run();
        }

        protected virtual void OnDestroy()
        {
            Destroy();
        }

        public void Destroy()
        {
            _runSystems?.Destroy();
            _runSystems = null;
            
            _fixedRunSystems?.Destroy();
            _fixedRunSystems = null;
            
            _world?.Destroy();
            _world = null;
        }
    }
}